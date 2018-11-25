/// <reference path="../typings/xrm.d.ts" />
/// <reference path="../typings/forms.d.ts" />
//#include tools/polyfill.js
//#include tools/kipon.xrmservice.js
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Demo;
(function (Demo) {
    var Account;
    (function (Account) {
        var Contact = /** @class */ (function (_super) {
            __extends(Contact, _super);
            function Contact() {
                var _this = _super.call(this, 'contacts', 'contactid', true) || this;
                _this.accountrolecode = new Kipon.OptionSetValue();
                _this.createdon = new Date();
                _this.creditlimit = null;
                _this.firstname = null;
                _this.lastname = null;
                _this.parentcustomerid = new Kipon.EntityReference().meta("accounts", "parentcustomerid_account");
                return _this;
            }
            Contact.prototype.meta = function () {
                this.creditlimit = 0.0000000001;
                return this;
            };
            return Contact;
        }(Kipon.Entity));
        Account.Contact = Contact;
        function loadForm(ctx) {
            var contactPrototype = new Contact();
            if (ctx.getFormContext().ui.getFormType() == 1 /* Create */) {
            }
            var xrmFrom = ctx.getFormContext();
            var form = ctx.getFormContext();
            var lo = form.getAttribute("primarycontactid");
            form.getControl("primarycontactid").addPreSearch(Demo.Account.doSearch);
            var val = lo.getValue();
            var contact;
            var pk = form.getAttribute("primarycontactid").getValue();
            if (pk != null && pk.length > 0) {
                var s = new Kipon.XrmService();
                var condition = new Kipon.Condition();
                condition.where("contactid", Kipon.Comparator.Equals, pk[0].id);
                var contacts = s.query(contactPrototype, condition).subscribe(function (r) {
                    contact = r.value[0];
                    console.log(contact);
                });
            }
        }
        Account.loadForm = loadForm;
        function SetOptionValues(field, vals) {
            field.clearOptions();
            vals.forEach(function (r) {
                field.addOption({ value: 1, text: 'xxxx' }, 0);
            });
        }
        Account.SetOptionValues = SetOptionValues;
        function doSearch(ctx) {
        }
        Account.doSearch = doSearch;
    })(Account = Demo.Account || (Demo.Account = {}));
})(Demo || (Demo = {}));
//# sourceMappingURL=AccountForm.js.map