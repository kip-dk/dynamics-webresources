//#include tools/polyfill.js
//#include tools/kipon.xrmservice.js

module Demo.Account {
    export class Contact extends Kipon.Entity {
        constructor() {
            super("contacts", "contactid")
        }
        fullname: string = null;
    }

    let contactPrototype: Contact = new Contact();

    export function loadForm(ctx: Xrm.Events.EventContext): void {
        let form = ctx.getFormContext() as XrmForm.AccountForm;

        let lo = form.getAttribute("primarycontactid");

        var val = lo.getValue();

        if (val != null && val.length > 0) {
            let s = new Kipon.XrmService();

            s.get<Contact>(contactPrototype, val[0].id)
                .subscribe(r => {
                    console.log(r);
                });
        }
    }
}
