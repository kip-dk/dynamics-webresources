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
            var form = ctx.getFormContext();
            var lo = form.getAttribute("primarycontactid");
            var t = form.ui.tabs.get("known").sections.get("alsoknown");
            var pc = form.getAttribute("primarycontactid");
            form.ui.controls.get("knowncontrol").getControlType;
            var ot = form.getAttribute("xx");
            ctx.getFormContext().getAttribute("primarycontactid").getValue();
            var s = new Kipon.Webapi.Service();
            s.get("contacts", "")
                .subscribe(function (r) { })
                .catch(function (m) { return console.log(m); });
        }
        function onsave(ctx) {
        }
    })(Account = Kipon.Account || (Kipon.Account = {}));
})(Kipon || (Kipon = {}));
//# sourceMappingURL=AccountForm.js.map