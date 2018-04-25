var Wa;
(function (Wa) {
    var Observable = /** @class */ (function () {
        function Observable() {
            this.subscribers = [];
            this.errors = [];
        }
        Observable.prototype.subscribe = function (t) {
            this.subscribers.push(t);
            return this;
        };
        Observable.prototype.catch = function (t) {
            this.errors.push(t);
            return this;
        };
        return Observable;
    }());
    Wa.Observable = Observable;
    var Http = /** @class */ (function () {
        function Http() {
            this.ctx = Xrm.Utility.getGlobalContext();
        }
        Http.prototype.get = function (url) {
            var _this = this;
            var result = new Observable();
            setTimeout(function () {
                _this.httpgetdelete(url, "GET", result);
            }, 1);
            return result;
        };
        Http.prototype.post = function (url, obj) {
            var _this = this;
            var result = new Observable();
            setTimeout(function () {
                _this.httppostpatchput(url, obj, "POST", result);
            }, 1);
            return result;
        };
        Http.prototype.patch = function (url, obj) {
            var _this = this;
            var result = new Observable();
            setTimeout(function () {
                _this.httppostpatchput(url, obj, "PATCH", result);
            }, 1);
            return result;
        };
        Http.prototype.put = function (url, obj) {
            var _this = this;
            var result = new Observable();
            setTimeout(function () {
                _this.httppostpatchput(url, obj, "PUT", result);
            }, 1);
            return result;
        };
        Http.prototype.delete = function (url) {
            var _this = this;
            var result = new Observable();
            setTimeout(function () {
                _this.httpgetdelete(url, "DELETE", result);
            }, 1);
            return result;
        };
        Http.prototype.httpgetdelete = function (relativeurl, method, promise) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            var url = this.ctx.getClientUrl() + relativeurl;
            var req = new XMLHttpRequest();
            req.open(method, url, true);
            this.setHeaders(req);
            this.listen(req, promise);
            req.send();
        };
        Http.prototype.httppostpatchput = function (relativeurl, obj, method, promise) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            var url = this.ctx.getClientUrl() + relativeurl;
            var req = new XMLHttpRequest();
            req.open(method, url, true);
            this.setHeaders(req);
            req.setRequestHeader("Prefer", "return=representation");
            this.listen(req, promise);
            req.send(JSON.stringify(obj));
        };
        Http.prototype.setHeaders = function (req) {
            req.setRequestHeader("OData-MaxVersion", "4.0");
            req.setRequestHeader("OData-Version", "4.0");
            req.setRequestHeader("Accept", "application/json");
            req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            req.setRequestHeader("Prefer", "odata.include-annotations=\"*\"");
        };
        Http.prototype.listen = function (req, promise) {
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
        };
        return Http;
    }());
    Wa.Http = Http;
})(Wa || (Wa = {}));
//# sourceMappingURL=wa.js.map