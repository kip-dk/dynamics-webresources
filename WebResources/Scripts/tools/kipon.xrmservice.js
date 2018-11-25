//merge: always
var Kipon;
(function (Kipon) {
    var Observable = /** @class */ (function () {
        function Observable() {
            this.subscribers = [];
            this.maps = [];
            this.errors = [];
        }
        Observable.prototype.subscribe = function (t) {
            this.subscribers.push(t);
            return this;
        };
        Observable.prototype.map = function (t) {
            this.maps.push(t);
            return this;
        };
        Observable.prototype.catch = function (t) {
            this.errors.push(t);
            return this;
        };
        return Observable;
    }());
    Kipon.Observable = Observable;
    var Http = /** @class */ (function () {
        function Http() {
            if (Xrm.Utility != null && Xrm.Utility.getGlobalContext != null) {
                this.ctx = Xrm.Utility.getGlobalContext();
            }
            if (this.ctx == null) {
                this.ctx = window["Xrm"]["Page"]["context"];
            }
            var ve = this.ctx.getVersion();
            if (ve != null && ve.length == 0) {
                var v = ve.split('.');
                this.ver = 'v' + v[0] + '.' + v[1];
            }
            else {
                this.ver = 'v8.0';
            }
        }
        Http.prototype.clientUrl = function () {
            return this.ctx.getClientUrl() + '/api/data/' + this.ver + '/';
        };
        Http.prototype.get = function (url, top) {
            var _this = this;
            if (top === void 0) { top = 0; }
            var result = new Observable();
            setTimeout(function () {
                _this.httpgetdelete(url, "GET", top, result);
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
                _this.httpgetdelete(url, "DELETE", null, result);
            }, 1);
            return result;
        };
        Http.prototype.httpgetdelete = function (relativeurl, method, top, promise) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            var url = this.clientUrl() + relativeurl;
            var req = new XMLHttpRequest();
            req.open(method, url, true);
            this.setHeaders(req);
            if (top != null && top > 0) {
                req.setRequestHeader("Prefer", "odata.maxpagesize=" + top.toString());
            }
            this.listen(req, promise);
            req.send();
        };
        Http.prototype.httppostpatchput = function (relativeurl, obj, method, promise) {
            if (promise.subscribe == null || promise.subscribe.length == 0) {
                return;
            }
            var url = this.clientUrl() + relativeurl;
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
                        var maps = promise["maps"];
                        if (maps != null && maps.length > 0) {
                            maps.forEach(function (r) {
                                result = r(result);
                            });
                        }
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
    Kipon.Http = Http;
    var Expand = /** @class */ (function () {
        function Expand() {
        }
        return Expand;
    }());
    Kipon.Expand = Expand;
    var Entity = /** @class */ (function () {
        function Entity(pluralName, keyName, updateable) {
            if (updateable === void 0) { updateable = false; }
            this._updateable = false;
            this._pluralName = pluralName;
            this._keyName = keyName;
            this._updateable = updateable;
        }
        return Entity;
    }());
    Kipon.Entity = Entity;
    var EntityReference = /** @class */ (function () {
        function EntityReference(id) {
            if (id === void 0) { id = null; }
            this.id = id;
        }
        EntityReference.prototype.meta = function (pluralName, associatednavigationproperty) {
            this.pluralName = pluralName;
            this.associatednavigationproperty = associatednavigationproperty;
            return this;
        };
        EntityReference.prototype.clone = function () {
            var result = new EntityReference();
            result.id = this.id;
            result.name = this.name;
            result.logicalname = this.name;
            result.associatednavigationproperty = this.associatednavigationproperty;
            return result;
        };
        EntityReference.prototype.associatednavigationpropertyname = function () {
            if (this.associatednavigationproperty == null || this.associatednavigationproperty == '') {
                throw 'navigation property has not been set for this EntityReference instance';
            }
            if (this.associatednavigationproperty["endsWith"]('@odata.bind')) {
                return this.associatednavigationproperty;
            }
            return this.associatednavigationproperty + '@odata.bind';
        };
        EntityReference.prototype.equals = function (ref) {
            return this.id == ref.id && this.logicalname == ref.logicalname;
        };
        EntityReference.same = function (ref1, ref2) {
            if (ref1 == null && ref2 == null) {
                return true;
            }
            var id1 = null;
            var id2 = null;
            if (ref1 != null)
                id1 = ref1.id;
            if (ref2 != null)
                id2 = ref2.id;
            return id1 == id2;
        };
        return EntityReference;
    }());
    Kipon.EntityReference = EntityReference;
    var OptionSetValue = /** @class */ (function () {
        function OptionSetValue(value, name) {
            if (value === void 0) { value = null; }
            if (name === void 0) { name = null; }
            this.value = value;
            this.name = name;
        }
        OptionSetValue.prototype.equals = function (o) {
            if (this.value == null && (o == null || o.value == null))
                return true;
            return this.value == o.value;
        };
        OptionSetValue.prototype.clone = function () {
            var r = new OptionSetValue();
            r.name = this.name;
            r.value = this.value;
            return r;
        };
        OptionSetValue.same = function (o1, o2) {
            if (o1 == null && o2 == null)
                return true;
            var v1 = null;
            var v2 = null;
            if (o1 != null)
                v1 = o1.value;
            if (o2 != null)
                v2 = o2.value;
            return v1 == v2;
        };
        return OptionSetValue;
    }());
    Kipon.OptionSetValue = OptionSetValue;
    var Operator;
    (function (Operator) {
        Operator[Operator["And"] = 0] = "And";
        Operator[Operator["Or"] = 1] = "Or";
    })(Operator = Kipon.Operator || (Kipon.Operator = {}));
    var Comparator;
    (function (Comparator) {
        Comparator[Comparator["Equals"] = 0] = "Equals";
        Comparator[Comparator["NotEquals"] = 1] = "NotEquals";
        Comparator[Comparator["Contains"] = 2] = "Contains";
        Comparator[Comparator["NotContains"] = 3] = "NotContains";
        Comparator[Comparator["DoesNotContainsData"] = 4] = "DoesNotContainsData";
        Comparator[Comparator["ContainsData"] = 5] = "ContainsData";
        Comparator[Comparator["StartsWith"] = 6] = "StartsWith";
        Comparator[Comparator["NotStartsWith"] = 7] = "NotStartsWith";
        Comparator[Comparator["EndsWith"] = 8] = "EndsWith";
        Comparator[Comparator["NotEndsWith"] = 9] = "NotEndsWith";
        Comparator[Comparator["GreaterThan"] = 10] = "GreaterThan";
        Comparator[Comparator["GreaterThanOrEqual"] = 11] = "GreaterThanOrEqual";
        Comparator[Comparator["LessThan"] = 12] = "LessThan";
        Comparator[Comparator["LessThanOrEQual"] = 13] = "LessThanOrEQual";
    })(Comparator = Kipon.Comparator || (Kipon.Comparator = {}));
    var ColumnBuilder = /** @class */ (function () {
        function ColumnBuilder() {
            this.columns = null;
            this.hasEntityReference = false;
        }
        return ColumnBuilder;
    }());
    Kipon.ColumnBuilder = ColumnBuilder;
    var Filter = /** @class */ (function () {
        function Filter() {
        }
        Filter.prototype.toQueryString = function (prototype) {
            var result = '';
            var _f = this.field;
            var _v = "'" + this.value + "'";
            if (typeof this.value == 'number') {
                _v = this.value.toString();
            }
            if (typeof this.value == 'boolean') {
                _v = this.value.valueOf() ? 'true' : 'false';
            }
            if (prototype[this.field] instanceof OptionSetValue) {
                if (this.value != null && this.value.hasOwnProperty('value')) {
                    _v = this.value.value;
                }
            }
            if (prototype[this.field] instanceof EntityReference) {
                _f = "_" + this.field + "_value";
                if (this.value != null) {
                    if (typeof this.value == 'string') {
                        _v = this.value;
                    }
                    else {
                        _v = this.value.id;
                    }
                }
            }
            if (_f["startsWith"]('_') && _f["endsWith"]('_value') && _v != null) {
                _v = this.value.replace('{', '').replace('}', '');
            }
            if (_f == prototype._keyName) {
                _v = this.value.replace('{', '').replace('}', '');
            }
            switch (this.operator) {
                case Comparator.Equals: {
                    return _f + ' eq ' + _v;
                }
                case Comparator.NotEquals: {
                    return _f + ' ne ' + _v;
                }
                case Comparator.GreaterThan: {
                    return _f + ' gt ' + _v;
                }
                case Comparator.GreaterThanOrEqual: {
                    return _f + ' ge ' + _v;
                }
                case Comparator.LessThan: {
                    return _f + ' lt ' + _v;
                }
                case Comparator.LessThanOrEQual: {
                    return _f + ' le ' + _v;
                }
                case Comparator.Contains: {
                    return "contains(" + _f + "," + _v + ")";
                }
                case Comparator.NotContains: {
                    return "not contains(" + _f + "," + _v + ")";
                }
                case Comparator.StartsWith: {
                    return "startswith(" + _f + "," + _v + ")";
                }
                case Comparator.NotStartsWith: {
                    return "not startswith(" + _f + "," + _v + ")";
                }
                case Comparator.EndsWith: {
                    return "endswith(" + _f + "," + _v + ")";
                }
                case Comparator.NotEndsWith: {
                    return "not endswith(" + _f + "," + _v + ")";
                }
                case Comparator.ContainsData: {
                    return _f + ' ne null';
                }
                case Comparator.DoesNotContainsData: {
                    return _f + ' eq null';
                }
            }
            return result;
        };
        return Filter;
    }());
    Kipon.Filter = Filter;
    var Condition = /** @class */ (function () {
        function Condition(operator) {
            if (operator === void 0) { operator = Operator.And; }
            this.operator = Operator.And;
            this.operator = operator;
            this.filter = [];
            this.children = [];
        }
        Condition.prototype.where = function (field, opr, value) {
            if (value === void 0) { value = null; }
            var f = new Filter();
            f.field = field;
            f.value = value;
            f.operator = opr;
            this.filter.push(f);
            return this;
        };
        Condition.prototype.group = function (opr) {
            var result = new Condition(opr);
            result.parent = this;
            this.children.push(result);
            return result;
        };
        Condition.prototype.isActive = function () {
            return this.where("statecode", Comparator.Equals, 0);
        };
        Condition.prototype.isInactive = function () {
            return this.where("statecode", Comparator.Equals, 1);
        };
        Condition.prototype.toQueryString = function (prototype) {
            if ((this.children == null || this.children.length == 0) && (this.filter == null || this.filter.length == 0)) {
                return null;
            }
            var me = this;
            var result = '';
            var opr = '';
            if (this.filter != null && this.filter.length > 0) {
                this.filter.forEach(function (r) {
                    result += opr + r.toQueryString(prototype);
                    if (me.operator == Operator.And) {
                        opr = ' and ';
                    }
                    else {
                        opr = ' or ';
                    }
                });
            }
            if (this.children != null && this.children.length > 0) {
                this.children.forEach(function (c) {
                    result += opr + "(" + c.toQueryString(prototype) + ")";
                    if (me.operator == Operator.And) {
                        opr = ' and ';
                    }
                    else {
                        opr = ' or ';
                    }
                });
            }
            return result;
        };
        return Condition;
    }());
    Kipon.Condition = Condition;
    var XrmTransactionItem = /** @class */ (function () {
        function XrmTransactionItem(type, prototype, instance, field, value) {
            if (field === void 0) { field = null; }
            if (value === void 0) { value = null; }
            this.id = null;
            this.type = type;
            this.prototype = prototype;
            this.instance = instance;
            this.field = field;
            this.value = value;
        }
        return XrmTransactionItem;
    }());
    var XrmTransaction = /** @class */ (function () {
        function XrmTransaction() {
            this.oprs = [];
        }
        XrmTransaction.prototype.put = function (prototype, instance, field, value) {
            this.oprs.push(new XrmTransactionItem("put", prototype, instance, field, value));
        };
        XrmTransaction.prototype.delete = function (instance) {
            this.oprs.push(new XrmTransactionItem("delete", null, instance));
        };
        XrmTransaction.prototype.create = function (prototype, instance) {
            this.oprs.push(new XrmTransactionItem("create", prototype, instance));
        };
        XrmTransaction.prototype.update = function (prototype, instance) {
            this.oprs.push(new XrmTransactionItem("update", prototype, instance));
        };
        return XrmTransaction;
    }());
    Kipon.XrmTransaction = XrmTransaction;
    var XrmAccess = /** @class */ (function () {
        function XrmAccess(lazy) {
            if (lazy === void 0) { lazy = false; }
            this.lazy = null;
            this.resolved = null;
            this.lazy = lazy;
        }
        return XrmAccess;
    }());
    Kipon.XrmAccess = XrmAccess;
    var ExpandProperty = /** @class */ (function () {
        function ExpandProperty() {
        }
        return ExpandProperty;
    }());
    var XrmService = /** @class */ (function () {
        function XrmService() {
            this.context = {};
            this.changemanager = {};
            this.tick = new Date().valueOf();
            this.debug = false;
            this.http = new Http();
        }
        XrmService.prototype.get = function (prototype, id) {
            var me = this;
            var columnDef = this.columnBuilder(prototype);
            var expand = null;
            var ep = this.getExpandProperty(prototype);
            if (ep != null) {
                expand = this.$expandToExpand(ep);
            }
            var _ex = this.expandString(expand, "&");
            var _id = this.toGuid(id);
            var url = prototype._pluralName + "(" + _id + ")?$select=" + columnDef.columns + _ex;
            return this.http.get(url).map(function (r) {
                return me.resolve(prototype, r, prototype._updateable);
            });
        };
        XrmService.prototype.query = function (prototype, condition, orderBy, top, count) {
            if (orderBy === void 0) { orderBy = null; }
            if (top === void 0) { top = 0; }
            if (count === void 0) { count = false; }
            var me = this;
            var fields = this.columnBuilder(prototype).columns;
            var con = condition;
            while (con.parent != null)
                con = con.parent;
            var filter = con.toQueryString(prototype);
            var url = prototype._pluralName;
            if ((fields != null && fields != '') || (filter != null && filter != '') || (orderBy != null && orderBy != '') || top > 0) {
                url += "?";
            }
            var sep = '';
            if (fields != null && fields != '') {
                url += '$select=' + fields;
                sep = '&';
            }
            if (filter != null && filter != '') {
                url += sep + '$filter=' + filter;
                sep = '&';
            }
            if (orderBy != null && orderBy != '') {
                url += sep + '$orderby=' + orderBy;
                sep = '&';
            }
            if (count) {
                url += sep + '$count=true';
                sep = '&';
            }
            if (this.debug)
                console.log(url);
            var pu = this.http.clientUrl() + url;
            return this.http.get(url).map(function (response) {
                var result = me.resolveQueryResult(prototype, response, top, [pu], 0);
                return result;
            });
        };
        XrmService.prototype.create = function (prototype, instance) {
            var _this = this;
            var newr = this.prepareNewInstance(prototype, instance);
            if (this.debug) {
                console.log(newr);
            }
            return this.http.post(prototype._pluralName, newr).map(function (response) {
                if (_this.debug) {
                    console.log(response);
                }
                if (response != null) {
                    if (response.hasOwnProperty('$keyonly')) {
                        response._pluralName = prototype._pluralName;
                        response._keyName = prototype._keyName;
                        response._updateable = false;
                        var key = response._pluralName + ':' + response.id;
                        for (var prop in prototype) {
                            if (typeof prototype[prop] === 'function') {
                                response[prop] = prototype[prop];
                                continue;
                            }
                            if (prototype.hasOwnProperty(prop)) {
                                if (_this.ignoreColumn(prop))
                                    continue;
                                var value = instance[prop];
                                if (value !== null) {
                                    response[prop] = value;
                                }
                            }
                        }
                        _this.context[key] = response;
                        return response;
                    }
                    else {
                        return _this.resolve(prototype, response, true);
                    }
                }
                return null;
            });
        };
        XrmService.prototype.prepareUpdate = function (prototype, instance) {
            var me = this;
            var upd = {};
            var countFields = 0;
            var key = instance._pluralName + ':' + instance.id;
            var cm = this.changemanager[key];
            if (typeof cm === 'undefined' || cm === null) {
                throw 'the object is not under change control and cannot be updated within this context';
            }
            for (var prop in prototype) {
                if (prototype.hasOwnProperty(prop) && typeof prototype[prop] != 'function') {
                    if (this.ignoreColumn(prop))
                        continue;
                    var prevValue = cm[prop];
                    var newValue = instance[prop];
                    if ((prevValue === 'undefined' || prevValue === null) && (newValue === 'undefined' || newValue === null))
                        continue;
                    if (prototype[prop] instanceof EntityReference) {
                        var r = prototype[prop];
                        if (!EntityReference.same(prevValue, newValue)) {
                            if (newValue != null && newValue["id"] != null && newValue["id"] != '') {
                                upd[prototype[prop]['associatednavigationpropertyname']()] = '/' + prototype[prop]['pluralName'] + '(' + newValue['id'] + ')';
                            }
                            else {
                                upd[prototype[prop]['associatednavigationpropertyname']()] = null;
                            }
                            countFields++;
                        }
                        continue;
                    }
                    if (prototype[prop] instanceof OptionSetValue) {
                        if (!OptionSetValue.same(prevValue, newValue)) {
                            var o = newValue;
                            if (o == null || o.value == null) {
                                upd[prop.toString()] = null;
                            }
                            else {
                                upd[prop.toString()] = o.value;
                            }
                            countFields++;
                        }
                        continue;
                    }
                    if (prototype[prop] instanceof Date) {
                        if (prevValue != newValue) {
                            if (newValue == null) {
                                upd[prop.toString()] = null;
                            }
                            else {
                                var d = newValue;
                                upd[prop.toString()] = d.toISOString();
                            }
                            countFields++;
                        }
                        continue;
                    }
                    if (prevValue != newValue) {
                        upd[prop.toString()] = instance[prop];
                        countFields++;
                    }
                }
            }
            if (countFields > 0) {
                return upd;
            }
            return null;
        };
        XrmService.prototype.resolveAccess = function (prototype, instance) {
            this.mapAccess(prototype, instance).subscribe(function (r) { });
        };
        XrmService.prototype.mapAccess = function (prototype, instance) {
            var _this = this;
            if (!prototype.hasOwnProperty('access') || !(prototype['access'] instanceof XrmAccess)) {
                return;
            }
            if (!instance.hasOwnProperty('access')) {
                instance['access'] = new XrmAccess();
            }
            else {
                var r_1 = instance['access'];
                if (r_1.resolved != null) {
                    return;
                }
            }
            var r = instance['access'];
            r.resolved = false;
            var url = "systemusers(" + this.http.ctx.getUserId() + ")/Microsoft.Dynamics.CRM.RetrievePrincipalAccess(Target=@tid)?@tid={\"@odata.id\":\"" + prototype._pluralName + "(" + instance.id + ")\"}";
            if (this.debug) {
                console.log(url);
            }
            return this.http.get(url).map(function (r) {
                if (_this.debug) {
                    console.log(r);
                }
                var i = instance['access'];
                var perm = r["AccessRights"];
                // ReadAccess, WriteAccess, AppendAccess, AppendToAccess, CreateAccess, DeleteAccess, ShareAccess, AssignAccess
                i.append = perm.indexOf('AppendAccess') >= 0;
                i.appendTo = perm.indexOf('AppendToAccess') >= 0;
                i.assign = perm.indexOf('AssignAccess') >= 0;
                i.create = perm.indexOf('CreateAccess') >= 0;
                i.delete = perm.indexOf('DeleteAccess') >= 0;
                i.read = perm.indexOf('ReadAccess') >= 0;
                i.share = perm.indexOf('ShareAccess') >= 0;
                i.write = perm.indexOf('WriteAccess') >= 0;
                i.resolved = true;
                return instance;
            });
        };
        XrmService.prototype.preparePutValue = function (prototype, field, value) {
            var t = prototype[field];
            if (t instanceof OptionSetValue) {
                if (value == null || value['value'] == null) {
                    return { field: field, value: null, propertyAs: 'value' };
                }
                else {
                    return { field: field, value: value['value'], propertyAs: 'value' };
                }
            }
            if (typeof t == 'number' && typeof value == 'number') {
                if (value == null) {
                    return { field: field, value: null, propertyAs: null };
                }
                else {
                    // this is a really really stupid hack, because dynamics do not accept Integer for decimal fields, so we force 
                    // a decimal position into the value before it is send.
                    var rv = value + t;
                    return { field: field, value: rv, propertyAs: 'value' };
                }
            }
            if (t instanceof EntityReference) {
                field = t.associatednavigationpropertyname().split('@')[0] + "/$ref";
                if (value.id == null || value.id == '') {
                    return { field: field, value: null, propertyAs: '@odata.id', isDefault: false };
                }
                else {
                    return { field: field, value: this.http.ctx.getClientUrl() + '' + t.pluralName + "(" + value.id + ")", propertyAs: '@odata.id', isdecimal: false };
                }
            }
            return { field: field, value: value, propertyAs: 'value' };
        };
        XrmService.prototype.prepareNewInstance = function (prototype, instance) {
            var newr = {};
            for (var prop in prototype) {
                if (prototype.hasOwnProperty(prop) && typeof prototype[prop] !== 'function') {
                    if (this.ignoreColumn(prop))
                        continue;
                    var value = instance[prop];
                    if (value !== 'undefined' && value !== null) {
                        if (prototype[prop] instanceof EntityReference) {
                            var ref = instance[prop];
                            if (ref != null && ref.id != null) {
                                newr[prototype[prop]['associatednavigationpropertyname']()] = '/' + prototype[prop]['pluralName'] + '(' + ref.id + ')';
                            }
                            continue;
                        }
                        if (prototype[prop] instanceof OptionSetValue) {
                            var o = instance[prop];
                            if (o != null && o.value != null) {
                                newr[prop.toString()] = o.value;
                            }
                            continue;
                        }
                        if (prototype[prop] instanceof Date) {
                            var d = value;
                            if (d != null) {
                                newr[prop.toString()] = d.toISOString();
                            }
                            continue;
                        }
                        newr[prop.toString()] = instance[prop];
                    }
                }
            }
            return newr;
        };
        XrmService.prototype.assignValue = function (prototype, instance, prop, value) {
            if (value != null) {
                instance[prop] = value;
                return;
            }
            var t = prototype[prop];
            if (t instanceof EntityReference) {
                instance[prop] = t.clone();
                return;
            }
            if (t instanceof OptionSetValue) {
                instance[prop] = new OptionSetValue();
                return;
            }
            instance[prop] = null;
        };
        XrmService.prototype.$expandToExpand = function (prop) {
            if (prop != null) {
                var result = new Expand();
                result.name = prop.name;
                result.select = this.columnBuilder(prop.entity).columns;
                return result;
            }
            return null;
        };
        XrmService.prototype.resolveQueryResult = function (prototype, response, top, pages, pageIndex) {
            var me = this;
            var result = {
                context: response["@odata.context"],
                count: response["@odata.count"],
                value: [],
                pages: pages,
                pageIndex: pageIndex,
                top: top,
                nextLink: null,
                prev: null,
                next: null
            };
            var vals = response["value"];
            vals.forEach(function (r) {
                result.value.push(me.resolve(prototype, r, prototype._updateable));
            });
            var nextLink = response["@odata.nextLink"];
            if (nextLink != null && nextLink != '') {
                var start = nextLink.indexOf('/api/data/') + 15;
                nextLink = nextLink.substring(start);
                result = {
                    context: result.context,
                    count: result.count,
                    value: result.value,
                    pages: pages,
                    pageIndex: pageIndex,
                    top: top,
                    nextLink: nextLink,
                    prev: null,
                    next: function () {
                        return me.http.get(nextLink, top).map(function (r) {
                            pages.push(nextLink);
                            var pr = me.resolveQueryResult(prototype, r, top, pages, pageIndex + 1);
                            return pr;
                        });
                    }
                };
            }
            if (result.pageIndex >= 1) {
                result.prev = function () {
                    var lastPage = result.pages[result.pageIndex - 1];
                    return me.http.get(lastPage, top).map(function (r) {
                        result.pages.splice(result.pages.length - 1, 1);
                        var pr = me.resolveQueryResult(prototype, r, top, result.pages, result.pageIndex - 1);
                        return pr;
                    });
                };
            }
            return result;
        };
        XrmService.prototype.resolve = function (prototype, instance, updateable) {
            var me = this;
            var key = prototype._pluralName + ':' + instance[prototype._keyName];
            var result = instance;
            if (this.context.hasOwnProperty(key)) {
                result = this.context[key];
            }
            else {
                this.context[key] = result;
                result["id"] = instance[prototype._keyName];
                result["_pluralName"] = prototype._pluralName;
                result["_keyName"] = prototype._keyName;
                delete result[prototype._keyName];
            }
            result['_updateable'] = updateable;
            for (var prop in prototype) {
                if (this.ignoreColumn(prop))
                    continue;
                if (prototype.hasOwnProperty(prop) && typeof prototype[prop] != 'function') {
                    var done = false;
                    if (prototype[prop] instanceof EntityReference) {
                        var ref = new EntityReference();
                        var id = instance["_" + prop + "_value"];
                        if (id != null && id != 'undefined') {
                            ref.id = id.toLowerCase();
                            delete result["_" + prop + "_value"];
                            ref.logicalname = instance["_" + prop + "_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                            delete instance["_" + prop + "_value@Microsoft.Dynamics.CRM.lookuplogicalname"];
                            ref.name = instance["_" + prop + "_value@OData.Community.Display.V1.FormattedValue"];
                            delete instance["_" + prop + "_value@OData.Community.Display.V1.FormattedValue"];
                            ref.associatednavigationproperty = instance["_" + prop + "_value@Microsoft.Dynamics.CRM.associatednavigationproperty"];
                            delete instance["_" + prop + "_value@Microsoft.Dynamics.CRM.associatednavigationproperty"];
                        }
                        result[prop] = ref;
                        done = true;
                    }
                    if (!done && prototype[prop] instanceof OptionSetValue) {
                        var opt = new OptionSetValue();
                        opt.value = instance[prop];
                        opt.name = instance[prop + '@OData.Community.Display.V1.FormattedValue'];
                        result[prop] = opt;
                        done = true;
                    }
                    if (!done && prototype[prop] instanceof Date) {
                        var v = instance[prop];
                        if (v != null && v != '') {
                            result[prop] = new Date(Date.parse(v));
                        }
                        else {
                            result[prop] = null;
                        }
                        done = true;
                    }
                    if (!done) {
                        result[prop] = instance[prop];
                        done = true;
                    }
                }
                if (typeof prototype[prop] === 'function') {
                    result[prop] = prototype[prop];
                }
            }
            if (updateable) {
                this.updateCM(prototype, result);
            }
            var ep = this.getExpandProperty(prototype);
            if (ep != null) {
                if (ep.isArray) {
                    var _v = instance[ep.name];
                    if (_v != null && Array.isArray(_v)) {
                        var _tmp_1 = [];
                        _v.forEach(function (_r) {
                            _tmp_1.push(me.resolve(ep.entity, _r, false));
                        });
                        result[ep.name] = _tmp_1;
                    }
                }
                else {
                    var _v = instance[ep.name];
                    if (_v != null) {
                        result[ep.name] = this.resolve(ep.entity, _v, false);
                        result[ep.name]['_keyName'] = ep.entity._keyName;
                        result[ep.name]['_pluralName'] = ep.entity._pluralName;
                    }
                }
            }
            if (result['onFetch'] !== 'undefined' && result["onFetch"] != null && typeof result["onFetch"] === 'function') {
                result['onFetch']();
            }
            if (prototype.hasOwnProperty('access') && !prototype['access']['lazy']) {
                this.resolveAccess(prototype, instance);
            }
            return result;
        };
        XrmService.prototype.updateCM = function (prototype, instance) {
            var key = prototype._pluralName + ':' + instance['id'];
            var change = {};
            if (this.debug) {
                console.log('Adding to cm ' + key);
            }
            this.changemanager[key] = change;
            for (var prop in prototype) {
                if (this.ignoreColumn(prop))
                    continue;
                if (prototype.hasOwnProperty(prop) && typeof prototype[prop] != 'function') {
                    var v = instance[prop];
                    if (v == null)
                        continue;
                    var done = false;
                    if (v instanceof EntityReference) {
                        change[prop] = v.clone();
                        done = true;
                    }
                    if (!done && v instanceof OptionSetValue) {
                        change[prop] = v.clone();
                        done = true;
                    }
                    if (!done && v instanceof Date) {
                        change[prop] = new Date(v.valueOf());
                        done = true;
                    }
                    if (!done) {
                        change[prop] = v;
                        done = true;
                    }
                }
            }
            if (this.debug) {
                console.log(change);
            }
        };
        XrmService.prototype.columnBuilder = function (entity) {
            var hasEntityReference = false;
            var columns = entity._keyName;
            for (var prop in entity) {
                if (prop == entity._keyName)
                    continue;
                if (this.ignoreColumn(prop))
                    continue;
                var v = entity[prop];
                if (typeof v !== 'undefined' && v != null) {
                    if (Array.isArray(v)) {
                        continue;
                    }
                    if (v instanceof Entity) {
                        continue;
                    }
                }
                if (entity.hasOwnProperty(prop) && typeof (entity[prop] != 'function')) {
                    if (entity[prop] instanceof EntityReference) {
                        columns += "," + "_" + prop + "_value";
                        hasEntityReference = true;
                    }
                    else {
                        columns += "," + prop;
                    }
                }
            }
            var result = new ColumnBuilder();
            result.hasEntityReference = hasEntityReference;
            result.columns = columns;
            return result;
        };
        XrmService.prototype.getExpandProperty = function (entity) {
            for (var prop in entity) {
                if (prop == entity._keyName)
                    continue;
                if (this.ignoreColumn(prop))
                    continue;
                var _v = entity[prop];
                if (Array.isArray(_v)) {
                    if (_v.length > 0) {
                        var pt = _v[0];
                        return {
                            name: prop,
                            entity: pt,
                            isArray: true
                        };
                    }
                }
                else {
                    if (_v instanceof Entity) {
                        return {
                            name: prop,
                            entity: _v,
                            isArray: false
                        };
                    }
                }
            }
            return null;
        };
        XrmService.prototype.ignoreColumn = function (prop) {
            if (prop == "_pluralName" || prop == "_keyName" || prop == "id" || prop == '_updateable' || prop == '$expand' || prop == 'access') {
                return true;
            }
            return false;
        };
        XrmService.prototype.toGuid = function (v) {
            // 5C48BB2A-BFC0-4E56-A262-8494E0F6A8FD
            if (v == null || v == '') {
                return v;
            }
            v = decodeURIComponent(v).replace('{', '').replace('}', '');
            if (v.indexOf('-') >= 0) {
                return v;
            }
            return v.substr(0, 8) + '-' + v.substr(8, 4) + '-' + v.substr(12, 4) + '-' + v.substr(16, 4) + '-' + v.substr(20);
        };
        XrmService.prototype.expandString = function (expand, sep) {
            if (expand == null || expand.name == null || expand.name == '')
                return '';
            var _ex = sep + '$expand=' + expand.name;
            if (expand.select != null || expand.filter != null) {
                _ex += '(';
                var semi = '';
                if (expand.select != null) {
                    _ex += '$select=' + expand.select;
                    semi = ';';
                }
                if (expand.filter != null) {
                    _ex += semi + '$filter=' + expand.filter;
                }
                _ex += ')';
            }
            return _ex;
        };
        return XrmService;
    }());
    Kipon.XrmService = XrmService;
})(Kipon || (Kipon = {}));
//# sourceMappingURL=kipon.xrmservice.js.map