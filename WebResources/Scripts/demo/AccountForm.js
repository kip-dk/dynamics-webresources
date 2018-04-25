//#include tools/kipon.xrmservice.js
var Demo;
(function (Demo) {
    var Account;
    (function (Account) {
        class Contact extends Kipon.Entity {
            constructor() {
                super("contacts", "contactid");
                this.fullname = null;
            }
        }
        Account.Contact = Contact;
        let contactPrototype = new Contact();
        function loadForm(ctx) {
            let form = ctx.getFormContext();
            let lo = form.getAttribute("primarycontactid");
            var val = lo.getValue();
            if (val != null && val.length > 0) {
                let s = new Kipon.XrmService();
                s.get(contactPrototype, val[0].id)
                    .subscribe(r => {
                    console.log(r);
                });
            }
        }
        function onsave(ctx) {
        }
    })(Account = Demo.Account || (Demo.Account = {}));
})(Demo || (Demo = {}));
//# sourceMappingURL=AccountForm.js.map