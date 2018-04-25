//#include tools/webapi.service.js

module Kipon.Account {
    export class Contact {
        contactid: string;
        fullname: string;
    }

    function loadForm(ctx: Xrm.Events.EventContext): void {
        console.log(ctx);

        let form = ctx.getFormContext() as XrmForm.AccountForm;

        let lo = form.getAttribute("primarycontactid");


        let t = form.ui.tabs.get("known").sections.get("alsoknown");

        let pc = form.getAttribute("primarycontactid");

        form.ui.controls.get("primarycontactid").getControlType;

        var ot = form.getAttribute("xx");

        ctx.getFormContext().getAttribute("primarycontactid").getValue();

        let s = new Kipon.Webapi.Service();

        s.get<Contact>("contacts", "")
            .subscribe(r => { })
            .catch(m => console.log(m));

    }

    function onsave(ctx: Xrm.Events.EventContext): void {

    }
 }