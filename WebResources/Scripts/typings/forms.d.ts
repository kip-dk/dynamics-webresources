
declare namespace XrmForm {
    interface AccountForm  {
        getAttribute(name: "primarycontactid"): Xrm.Attributes.LookupAttribute;
        getControl(name: "primarycontactid"): Xrm.Controls.LookupControl;
        getAttribute(name: string): void;
        getControl(name: string): void;

        ui: AccountFormUI;
    }

    interface AccountFormUI {
        controls: AccountFormUIControls;
        tabs: AccountFormUITabs;
    }

    interface AccountFormUIControls  {
        get(name: "knowncontrol"): Xrm.Controls.Control;
        get(name: string): void;
    }


    interface AccountFormUITabs  {
        get(name: "known"): AccountFormUITabX;
        get(name: string): void;
    }

    interface AccountFormUITabX {
        sections: AccountFormUITabXSections;
    }

    interface AccountFormUITabXSections {
        get(name: "alsoknown"): Xrm.Controls.Section;
        get(name: string): void;
    }
}
