/// <reference path="../typings/xrm.d.ts" />
/// <reference path="../typings/forms.d.ts" />
//#include tools/polyfill.js
//#include tools/kipon.xrmservice.js
var Demo;
(function (Demo) {
    var Account;
    (function (Account) {
        class Contact extends Kipon.Entity {
            constructor() {
                super('contacts', 'contactid', true);
                this.accountrolecode = new Kipon.OptionSetValue();
                this.createdon = new Date();
                this.creditlimit = null;
                this.firstname = null;
                this.lastname = null;
                this.parentcustomerid = new Kipon.EntityReference().meta("accounts", "parentcustomerid_account");
            }
            meta() {
                this.creditlimit = 0.0000000001;
                return this;
            }
        }
        Account.Contact = Contact;
        function loadForm(ctx) {
            if (ctx.getFormContext().ui.getFormType() == 1 /* Create */) {
            }
            let xrmFrom = ctx.getFormContext();
            let form = ctx.getFormContext();
            let lo = form.getAttribute("primarycontactid");
            form.getControl("primarycontactid").addPreSearch(Demo.Account.doSearch);
            var val = lo.getValue();
            let contact;
            let pk = form.getAttribute("primarycontactid").getValue();
            if (pk != null && pk.length > 0) {
                let contactPrototype = new Contact();
                let s = new Kipon.XrmService();
                let condition = new Kipon.Condition();
                condition.where("contactid", Kipon.Comparator.Equals, pk[0].id);
                var contacts = s.query(contactPrototype, condition).subscribe(r => {
                    contact = r.value[0];
                    contact.accountrolecode;
                });
            }
        }
        Account.loadForm = loadForm;
        function SetOptionValues(field, vals) {
            field.clearOptions();
            vals.forEach(r => {
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