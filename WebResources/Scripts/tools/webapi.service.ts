//merge: always

module Kipon.Webapi {

    interface ICallback<T> {
        (t: T): void;
    }

    export class Promise<T> {
        private subscribers: ICallback<T>[] = [];
        private errors: any[] = [];

        subscribe(t: ICallback<T>): Promise<T> {
            this.subscribers.push(t);
            return this;
        }

        catch(t: ICallback<string>): Promise<T> {
            this.errors.push(t);
            return this;
        } 
    }

    export class Service {
        private ctx: Xrm.GlobalContext;
        private version: string;
        constructor() {
            this.ctx = Xrm.Utility.getGlobalContext();
            let v = this.ctx.getVersion();
            if (v != null && v != '') {
                let s = v.split('.');
                this.version = 'v' + s[0] + '.' + s[1];
            }
            this.version = 'v8.0';
        }

        get<T>(pluralname, id: string): Promise<T>
        get<T>(pluralname, id: string, fields: string): Promise<T>
        get<T>(pluralname, id: string, fields: string = null): Promise<T> {
            let result = new Promise<T>();
            setTimeout(() => {
                this.httpget(pluralname, id, fields, result);
            }, 1);
            return result;
        }


        private httpget<T>(pluralname: string, id: string, fields: string, promise: Promise<T>) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            let ctx = Xrm.Utility.getGlobalContext();
            let url = ctx.getClientUrl() + "/api/data/" + this.version + '/' + pluralname + '(' + this.decodeID(id) + ')';

            if (fields != null && fields != '') {
                url += '?$select=' + fields;
            }

            let req = new XMLHttpRequest();
            req.open("GET", url, true);
            req.setRequestHeader("OData-MaxVersion", "4.0");
            req.setRequestHeader("OData-Version", "4.0");
            req.setRequestHeader("Accept", "application/json");
            req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
            req.onreadystatechange = function () {
                if (this.readyState === 4) {
                    req.onreadystatechange = null;
                    if (this.status === 200) {
                        var result = JSON.parse(this.response) as T;
                        promise["subscribers"].forEach(r => {
                            r(result);
                        });
                    } else {
                        promise["errors"].forEach(e => {
                            e(this.statusText);
                        });
                    }
                }
            };
            req.send();
        }

        private decodeID(v: string): string {
            return decodeURIComponent(v).replace('{', '').replace('}', '');
        }
    }
}