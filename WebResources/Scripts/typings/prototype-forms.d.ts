declare namespace XrmFormPrototype {
    interface AccountFormPrototype  {
        getAttribute(name: "primarycontactid"): Xrm.Attributes.LookupAttribute;
        getControl(name: "primarycontactid"): Xrm.Controls.LookupControl;

        getAttribute(name: "name"): Xrm.Attributes.StringAttribute;
        getControl(name: "name"): Xrm.Controls.StringControl;

        getAttribute(name: "number"): Xrm.Attributes.NumberAttribute;
        getControl(name: "number"): Xrm.Controls.NumberControl;

        getAttribute(name: "bool"): Xrm.Attributes.BooleanAttribute;
        getControl(name: "bool"): Xrm.Controls.BooleanControl;

        getAttribute(name: "lookup"): Xrm.Attributes.LookupAttribute;
        getControl(name: "lookup"): Xrm.Controls.LookupControl;

        getAttribute(name: "date"): Xrm.Attributes.DateAttribute;
        getControl(name: "date"): Xrm.Controls.DateControl;

        getAttribute(name: "optionset"): Xrm.Attributes.OptionSetAttribute;
        getControl(name: "optionset"): Xrm.Controls.OptionSetControl;


        getAttribute(name: string): void;
        getControl(name: string): void;

        ui: AccountFormUI;
    }

    interface AccountFormUI {
        controls: AccountFormUIControls;
        tabs: AccountFormUITabs;
    }

    interface AccountFormUIControls  {
        get(name: "primarycontactid"): Xrm.Controls.LookupControl;
        get(name: string): void;
    }


    interface AccountFormUITabs  {
        get(name: "known"): AccountFormUITabNN;
        get(name: string): void;
    }

    interface AccountFormUITabNN extends Xrm.Controls.UiStandardElement, Xrm.Controls.UiFocusable  {
        sections: AccountFormUITabXSections;
    }

    interface AccountFormUITabXSections {
        get(name: "alsoknown"): Xrm.Controls.Section;
        get(name: string): void;
    }
}
