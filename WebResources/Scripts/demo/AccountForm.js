//#include tools/webapi.service.js
var Kipon;
(function (Kipon) {
    var Account;
    (function (Account) {
        var Contact = /** @class */ (function () {
            function Contact() {
            }
            return Contact;
        }());
        Account.Contact = Contact;
        function loadForm(ctx) {
            console.log(ctx);
            ctx.getFormContext().getAttribute("primarycontactid").getValue();
            var s = new Kipon.Webapi.Service();
            s.get("contacts", "")
                .subscribe(function (r) { })
                .catch(function (m) { return console.log(m); });
        }
    })(Account = Kipon.Account || (Kipon.Account = {}));
})(Kipon || (Kipon = {}));
//# sourceMappingURL=AccountForm.js.map