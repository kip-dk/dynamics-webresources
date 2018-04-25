//merge: always
var XKipon;
(function (XKipon) {
    var Webapi;
    (function (Webapi) {
        class Promise {
            constructor() {
                this.subscribers = [];
                this.errors = [];
            }
            subscribe(t) {
                this.subscribers.push(t);
                return this;
            }
            catch(t) {
                this.errors.push(t);
                return this;
            }
        }
        Webapi.Promise = Promise;
        class Service {
            constructor() {
                this.ctx = Xrm.Utility.getGlobalContext();
                let v = this.ctx.getVersion();
                if (v != null && v != '') {
                    let s = v.split('.');
                    this.version = 'v' + s[0] + '.' + s[1];
                }
                else {
                    this.version = 'v8.0';
                }
            }
            get(pluralname, id, fields = null) {
                let result = new Promise();
                setTimeout(() => {
                    this.httpget(pluralname, id, fields, result);
                }, 1);
                return result;
            }
            httpget(pluralname, id, fields, promise) {
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
                            var result = JSON.parse(this.response);
                            promise["subscribers"].forEach(r => {
                                r(result);
                            });
                        }
                        else {
                            promise["errors"].forEach(e => {
                                e(this.statusText);
                            });
                        }
                    }
                };
                req.send();
            }
            decodeID(v) {
                return decodeURIComponent(v).replace('{', '').replace('}', '');
            }
        }
        Webapi.Service = Service;
    })(Webapi = XKipon.Webapi || (XKipon.Webapi = {}));
})(XKipon || (XKipon = {}));
//# sourceMappingURL=webapi.service.js.map