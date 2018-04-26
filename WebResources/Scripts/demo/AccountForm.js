//#include tools/polyfill.js
//#include tools/kipon.xrmservice.js
var Demo;
(function (Demo) {
    var Account;
    (function (Account) {
        class Contact extends Kipon.Entity {
            constructor() {
                super("contacts", "contactid");
                this.fullname = null;
                this.parentcustomerid = new Kipon.EntityReference().meta("accounts", "parentcustomerid_account");
            }
        }
        Account.Contact = Contact;
        let contactPrototype = new Contact();
        function loadForm(ctx) {
            let form = ctx.getFormContext();
            let lo = form.getAttribute("primarycontactid");
            var val = lo.getValue();
            let s = new Kipon.XrmService();
            /*
            if (val != null && val.length > 0) {
    
                s.get<Contact>(contactPrototype, val[0].id)
                    .subscribe(r => {
                        // console.log(r);
                    });
            }
            */
            let con = new Kipon.Condition()
                .where("parentcustomerid", Kipon.Comparator.Equals, ctx.getFormContext().data.entity.getId());
            s.query(contactPrototype, con).subscribe(r => {
                if (r.value != null) {
                    r.value.forEach(c => {
                        console.log(c);
                    });
                }
            });
        }
        Account.loadForm = loadForm;
    })(Account = Demo.Account || (Demo.Account = {}));
})(Demo || (Demo = {}));
//# sourceMappingURL=AccountForm.js.map