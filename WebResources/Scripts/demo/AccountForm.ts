//#include tools/webapi.service.js

module Kipon.Account {
    export class Contact {
        contactid: string;
        fullname: string;
    }

    function loadForm(ctx: Xrm.Events.EventContext): void {
        console.log(ctx);

        ctx.getFormContext().getAttribute("primarycontactid").getValue();

        let s = new Kipon.Webapi.Service();

        s.get<Contact>("contacts", "")
            .subscribe(r => { })
            .catch(m => console.log(m));
    }
 }