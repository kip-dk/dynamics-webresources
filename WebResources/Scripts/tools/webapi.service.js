//merge: always
var Kipon;
(function (Kipon) {
    var Webapi;
    (function (Webapi) {
        var Promise = /** @class */ (function () {
            function Promise() {
                this.subscribers = [];
                this.errors = [];
            }
            Promise.prototype.subscribe = function (t) {
                this.subscribers.push(t);
                return this;
            };
            Promise.prototype.catch = function (t) {
                this.errors.push(t);
                return this;
            };
            return Promise;
        }());
        Webapi.Promise = Promise;
        var Service = /** @class */ (function () {
            function Service() {
                this.ctx = Xrm.Utility.getGlobalContext();
                var v = this.ctx.getVersion();
                if (v != null && v != '') {
                    var s = v.split('.');
                    this.version = 'v' + s[0] + '.' + s[1];
                }
                else {
                    this.version = 'v8.0';
                }
            }
            Service.prototype.get = function (pluralname, id, fields) {
                var _this = this;
                if (fields === void 0) { fields = null; }
                var result = new Promise();
                setTimeout(function () {
                    _this.httpget(pluralname, id, fields, result);
                }, 1);
                return result;
            };
            Service.prototype.httpget = function (pluralname, id, fields, promise) {
                if (promise.subscribe == null || promise.subscribe.length == 0) {
                    return;
                }
                var ctx = Xrm.Utility.getGlobalContext();
                var url = ctx.getClientUrl() + "/api/data/" + this.version + '/' + pluralname + '(' + this.decodeID(id) + ')';
                if (fields != null && fields != '') {
                    url += '?$select=' + fields;
                }
                var req = new XMLHttpRequest();
                req.open("GET", url, true);
                req.setRequestHeader("OData-MaxVersion", "4.0");
                req.setRequestHeader("OData-Version", "4.0");
                req.setRequestHeader("Accept", "application/json");
                req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
                req.onreadystatechange = function () {
                    var _this = this;
                    if (this.readyState === 4) {
                        req.onreadystatechange = null;
                        if (this.status === 200) {
                            var result = JSON.parse(this.response);
                            promise["subscribers"].forEach(function (r) {
                                r(result);
                            });
                        }
                        else {
                            promise["errors"].forEach(function (e) {
                                e(_this.statusText);
                            });
                        }
                    }
                };
                req.send();
            };
            Service.prototype.decodeID = function (v) {
                return decodeURIComponent(v).replace('{', '').replace('}', '');
            };
            return Service;
        }());
        Webapi.Service = Service;
    })(Webapi = Kipon.Webapi || (Kipon.Webapi = {}));
})(Kipon || (Kipon = {}));
//# sourceMappingURL=webapi.service.js.map