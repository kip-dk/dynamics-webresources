
module Wa {
    interface ICallback<T> {
        (t: T): void;
    }

    export class Observable<T> {
        private subscribers: ICallback<T>[] = [];
        private errors: any[] = [];

        subscribe(t: ICallback<T>): Observable<T> {
            this.subscribers.push(t);
            return this;
        }

        catch(t: ICallback<string>): Observable<T> {
            this.errors.push(t);
            return this;
        }
    }

    export class Http {
        ctx: Xrm.GlobalContext;

        constructor() {
            this.ctx = Xrm.Utility.getGlobalContext();
        }

        get<T>(url: string): Observable<T> {
            let result = new Observable<T>();
            setTimeout(() => {
                this.httpgetdelete(url, "GET",result);
            }, 1);
            return result;
        }

        post<T>(url: string, obj: any): Observable<T> {
            let result = new Observable<T>();
            setTimeout(() => {
                this.httppostpatchput(url, obj, "POST",result);
            },1);

            return result;
        }

        patch<T>(url: string, obj: any): Observable<T> {
            let result = new Observable<T>();
            setTimeout(() => {
                this.httppostpatchput(url, obj, "PATCH", result);
            }, 1);
            return result;
        }

        put<T>(url: string, obj: any): Observable<T> {
            let result = new Observable<T>();
            setTimeout(() => {
                this.httppostpatchput(url, obj, "PUT", result);
            }, 1);
            return result;
        }

        delete<T>(url: string): Observable<T> {
            let result = new Observable<T>();
            setTimeout(() => {
                this.httpgetdelete(url, "DELETE", result);
            }, 1);
            return result;
        }

        private httpgetdelete<T>(relativeurl: string, method: string, promise: Observable<T>) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            let url = this.ctx.getClientUrl() + relativeurl;

            let req = new XMLHttpRequest();
            req.open(method, url, true);
            this.setHeaders(req);
            this.listen<T>(req, promise);
            req.send();
        }

        private httppostpatchput<T>(relativeurl: string, obj: any, method: string, promise: Observable<T>) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            let url = this.ctx.getClientUrl() + relativeurl;

            let req = new XMLHttpRequest();
            req.open(method, url, true);
            this.setHeaders(req);
            req.setRequestHeader("Prefer", "return=representation");
            this.listen<T>(req, promise);
            req.send(JSON.stringify(obj));
        }


        private setHeaders(req: XMLHttpRequest): void {
            req.setRequestHeader("OData-MaxVersion", "4.0");
            req.setRequestHeader("OData-Version", "4.0");
            req.setRequestHeader("Accept", "application/json");
            req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
        }

        private listen<T>(req: XMLHttpRequest, promise: Observable<T>): void {
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
        }
    }


}