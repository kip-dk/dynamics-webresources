/// <reference path="../typings/xrm.d.ts" />
/// <reference path="../typings/forms.d.ts" />
//#include tools/polyfill.js
//#include tools/kipon.xrmservice.js

module Demo.Account {
    export class Contact extends Kipon.Entity {
        constructor() {
            super('contacts', 'contactid', true);
        }
        accountrolecode: Kipon.OptionSetValue = new Kipon.OptionSetValue();
        createdon: Date = new Date();
        creditlimit: number = null;
        firstname: string = null;
        lastname: string = null;
        parentcustomerid: Kipon.EntityReference = new Kipon.EntityReference().meta("accounts", "parentcustomerid_account");

        meta(): Contact {
            this.creditlimit = 0.0000000001;
            return this;
        }
    }

    export function loadForm(ctx: Xrm.Events.EventContext): void {
        let contactPrototype: Contact = new Contact();

        if (ctx.getFormContext().ui.getFormType() == XrmEnum.FormType.Create) {
        }

        let xrmFrom = ctx.getFormContext();

        let form = ctx.getFormContext() as XrmForm.AccountForm;

        let lo = form.getAttribute("primarycontactid");

        form.getControl("primarycontactid").addPreSearch(Demo.Account.doSearch);



        var val = lo.getValue();

        let contact: Contact;

        let pk = form.getAttribute("primarycontactid").getValue();
        if (pk != null && pk.length > 0) {

            let s = new Kipon.XrmService();
            let condition = new Kipon.Condition();
            condition.where("contactid", Kipon.Comparator.Equals, pk[0].id);

            var contacts = s.query(contactPrototype, condition).subscribe(r => {
                contact = r.value[0];
                console.log(contact);
            });
        }
    }

    export function SetOptionValues(field: Xrm.Controls.OptionSetControl, vals: number[]) {

        field.clearOptions();
        vals.forEach(r => {
            field.addOption({ value: 1, text:'xxxx' }, 0);
        })
    }

    export function doSearch(ctx: Xrm.Events.EventContext): void {
    }
}
