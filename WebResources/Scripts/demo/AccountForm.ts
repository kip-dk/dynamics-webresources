//#include tools/polyfill.js
//#include tools/kipon.xrmservice.js

module Demo.Account {
    export class Contact extends Kipon.Entity {
        constructor() {
            super("contacts", "contactid")
        }
        fullname: string = null;
        parentcustomerid: Kipon.EntityReference = new Kipon.EntityReference().meta("accounts", "parentcustomerid_account");
    }

    let contactPrototype: Contact = new Contact();

    export function loadForm(ctx: Xrm.Events.EventContext): void {
        let form = ctx.getFormContext() as XrmForm.AccountForm;

        let lo = form.getAttribute("primarycontactid");



        form.getControl("primarycontactid").addPreSearch(Demo.Account.doSearch);

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

    export function doSearch(ctx: Xrm.Events.EventContext): void {
    }
}
