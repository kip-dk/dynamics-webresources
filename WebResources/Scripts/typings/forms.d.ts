
declare namespace XrmForm {
    interface AccountForm extends Xrm.FormContext {
        getAttribute(name: "primarycontactid"): XrmForm.AttributeLookup;
        getControl(name: "primarycontactid"): XrmForm.LookupControl;

        getAttribute(name: string): XrmForm.AttributeEmpty;

        ui: AccountFormUI;
    }

    interface AccountFormUI extends Xrm.Ui {
        controls: AccountFormUIControls;
        tabs: AccountFormUITabs;
    }

    interface AccountFormUIControls extends Xrm.Collection.ItemCollection<Xrm.Controls.Control> {
        get(name: "knowncontrol"): Xrm.Controls.Control;
        get(name: string): void;
    }


    interface AccountFormUITabs extends Xrm.Collection.ItemCollection<Xrm.Controls.Tab> {
        get(name: "known"): AccountFormUITabX;
        get(name: string): void;
    }

    interface AccountFormUITabX extends Xrm.Controls.Tab {
        sections: AccountFormUITabXSections;
    }

    interface AccountFormUITabXSections extends Xrm.Collection.ItemCollection<Xrm.Controls.Section> {
        get(name: "alsoknown"): Xrm.Controls.Section;
        get(name: string): void;
    }
}