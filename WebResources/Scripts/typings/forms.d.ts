/// <reference path="xrm.d.ts" />

declare namespace XrmForm {
	interface AccountForm {
		getAttribute(name: string): void;
		getControl(name: string): void;
		getAttribute(name: "name"): Xrm.Attributes.StringAttribute;
		getControl(name: "name"): Xrm.Controls.StringControl;
		getAttribute(name: "telephone1"): Xrm.Attributes.StringAttribute;
		getControl(name: "telephone1"): Xrm.Controls.StringControl;
		getAttribute(name: "fax"): Xrm.Attributes.StringAttribute;
		getControl(name: "fax"): Xrm.Controls.StringControl;
		getAttribute(name: "websiteurl"): Xrm.Attributes.StringAttribute;
		getControl(name: "websiteurl"): Xrm.Controls.StringControl;
		getAttribute(name: "parentaccountid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "parentaccountid"): Xrm.Controls.LookupControl;
		getAttribute(name: "tickersymbol"): Xrm.Attributes.StringAttribute;
		getControl(name: "tickersymbol"): Xrm.Controls.StringControl;
		getAttribute(name: "lastonholdtime"): Xrm.Attributes.DateAttribute;
		getControl(name: "lastonholdtime"): Xrm.Controls.DateControl;
		getAttribute(name: "primarycontactid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "primarycontactid"): Xrm.Controls.LookupControl;
		getAttribute(name: "contactquickform"): Xrm.Attributes.LookupAttribute;
		getControl(name: "contactquickform"): Xrm.Controls.LookupControl;
		getAttribute(name: "sic"): Xrm.Attributes.StringAttribute;
		getControl(name: "sic"): Xrm.Controls.StringControl;
		getAttribute(name: "originatingleadid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "originatingleadid"): Xrm.Controls.LookupControl;
		getAttribute(name: "lastusedincampaign"): Xrm.Attributes.DateAttribute;
		getControl(name: "lastusedincampaign"): Xrm.Controls.DateControl;
		getAttribute(name: "donotsendmm"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotsendmm"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotemail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotemail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "followemail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "followemail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotbulkemail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotbulkemail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotphone"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotphone"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotfax"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotfax"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotpostalmail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotpostalmail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "transactioncurrencyid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "transactioncurrencyid"): Xrm.Controls.LookupControl;
		getAttribute(name: "creditlimit"): Xrm.Attributes.NumberAttribute;
		getControl(name: "creditlimit"): Xrm.Controls.NumberControl;
		getAttribute(name: "creditonhold"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "creditonhold"): Xrm.Controls.BooleanControl;
		getAttribute(name: "header_revenue"): Xrm.Attributes.NumberAttribute;
		getControl(name: "header_revenue"): Xrm.Controls.NumberControl;
		getAttribute(name: "header_ownerid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "header_ownerid"): Xrm.Controls.LookupControl;
		ui: AccountFormUI;
	}
	interface AccountFormUI  {
		controls: AccountFormUIControls;
		tabs: AccountFormUITabs;
    }
    interface AccountFormUIControls  {
		get(name: string): void;
		get(name: "name"): Xrm.Controls.StringControl;
		get(name: "telephone1"): Xrm.Controls.StringControl;
		get(name: "fax"): Xrm.Controls.StringControl;
		get(name: "websiteurl"): Xrm.Controls.StringControl;
		get(name: "parentaccountid"): Xrm.Controls.LookupControl;
		get(name: "tickersymbol"): Xrm.Controls.StringControl;
		get(name: "lastonholdtime"): Xrm.Controls.DateControl;
		get(name: "primarycontactid"): Xrm.Controls.LookupControl;
		get(name: "contactquickform"): Xrm.Controls.LookupControl;
		get(name: "sic"): Xrm.Controls.StringControl;
		get(name: "originatingleadid"): Xrm.Controls.LookupControl;
		get(name: "lastusedincampaign"): Xrm.Controls.DateControl;
		get(name: "donotsendmm"): Xrm.Controls.BooleanControl;
		get(name: "donotemail"): Xrm.Controls.BooleanControl;
		get(name: "followemail"): Xrm.Controls.BooleanControl;
		get(name: "donotbulkemail"): Xrm.Controls.BooleanControl;
		get(name: "donotphone"): Xrm.Controls.BooleanControl;
		get(name: "donotfax"): Xrm.Controls.BooleanControl;
		get(name: "donotpostalmail"): Xrm.Controls.BooleanControl;
		get(name: "transactioncurrencyid"): Xrm.Controls.LookupControl;
		get(name: "creditlimit"): Xrm.Controls.NumberControl;
		get(name: "creditonhold"): Xrm.Controls.BooleanControl;
		get(name: "header_revenue"): Xrm.Controls.NumberControl;
		get(name: "header_ownerid"): Xrm.Controls.LookupControl;
	}
	interface AccountFormUITabs  {
		get(name: string): void;
		get(name: "SUMMARY_TAB"): AccountFormUITab0;
		get(name: "DETAILS_TAB"): AccountFormUITab1;
	}
	interface AccountFormUITab0 extends Xrm.Controls.UiStandardElement, Xrm.Controls.UiFocusable {
		sections: AccountFormUITab0Sections;
	}
	interface AccountFormUITab1 extends Xrm.Controls.UiStandardElement, Xrm.Controls.UiFocusable {
		sections: AccountFormUITab1Sections;
	}
	interface AccountFormUITab0Sections {
		get(name: string): void;
		get(name: "ACCOUNT_INFORMATION"): Xrm.Controls.Section;
		get(name: "ADDRESS"): Xrm.Controls.Section;
		get(name: "MapSection"): Xrm.Controls.Section;
		get(name: "SOCIAL_PANE_TAB"): Xrm.Controls.Section;
		get(name: "SUMMARY_TAB_section_6"): Xrm.Controls.Section;
	}
	interface AccountFormUITab1Sections {
		get(name: string): void;
		get(name: "COMPANY_PROFILE"): Xrm.Controls.Section;
		get(name: "DETAILS_TAB_section_6"): Xrm.Controls.Section;
		get(name: "MARKETING"): Xrm.Controls.Section;
		get(name: "CONTACT_PREFERENCES"): Xrm.Controls.Section;
		get(name: "BILLING"): Xrm.Controls.Section;
		get(name: "SHIPPING"): Xrm.Controls.Section;
		get(name: "ChildAccounts"): Xrm.Controls.Section;
	}
	interface ContactForm {
		getAttribute(name: string): void;
		getControl(name: string): void;
		getAttribute(name: "fullname"): Xrm.Attributes.StringAttribute;
		getControl(name: "fullname"): Xrm.Controls.StringControl;
		getAttribute(name: "jobtitle"): Xrm.Attributes.StringAttribute;
		getControl(name: "jobtitle"): Xrm.Controls.StringControl;
		getAttribute(name: "parentcustomerid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "parentcustomerid"): Xrm.Controls.LookupControl;
		getAttribute(name: "emailaddress1"): Xrm.Attributes.StringAttribute;
		getControl(name: "emailaddress1"): Xrm.Controls.StringControl;
		getAttribute(name: "telephone1"): Xrm.Attributes.StringAttribute;
		getControl(name: "telephone1"): Xrm.Controls.StringControl;
		getAttribute(name: "mobilephone"): Xrm.Attributes.StringAttribute;
		getControl(name: "mobilephone"): Xrm.Controls.StringControl;
		getAttribute(name: "fax"): Xrm.Attributes.StringAttribute;
		getControl(name: "fax"): Xrm.Controls.StringControl;
		getAttribute(name: "parentcustomerid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "parentcustomerid"): Xrm.Controls.LookupControl;
		getAttribute(name: "contactquickform"): Xrm.Attributes.LookupAttribute;
		getControl(name: "contactquickform"): Xrm.Controls.LookupControl;
		getAttribute(name: "spousesname"): Xrm.Attributes.StringAttribute;
		getControl(name: "spousesname"): Xrm.Controls.StringControl;
		getAttribute(name: "birthdate"): Xrm.Attributes.DateAttribute;
		getControl(name: "birthdate"): Xrm.Controls.DateControl;
		getAttribute(name: "anniversary"): Xrm.Attributes.DateAttribute;
		getControl(name: "anniversary"): Xrm.Controls.DateControl;
		getAttribute(name: "originatingleadid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "originatingleadid"): Xrm.Controls.LookupControl;
		getAttribute(name: "lastusedincampaign"): Xrm.Attributes.DateAttribute;
		getControl(name: "lastusedincampaign"): Xrm.Controls.DateControl;
		getAttribute(name: "donotsendmm"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotsendmm"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotemail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotemail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "followemail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "followemail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotbulkemail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotbulkemail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotphone"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotphone"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotfax"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotfax"): Xrm.Controls.BooleanControl;
		getAttribute(name: "donotpostalmail"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "donotpostalmail"): Xrm.Controls.BooleanControl;
		getAttribute(name: "transactioncurrencyid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "transactioncurrencyid"): Xrm.Controls.LookupControl;
		getAttribute(name: "creditlimit"): Xrm.Attributes.NumberAttribute;
		getControl(name: "creditlimit"): Xrm.Controls.NumberControl;
		getAttribute(name: "creditonhold"): Xrm.Attributes.BooleanAttribute;
		getControl(name: "creditonhold"): Xrm.Controls.BooleanControl;
		getAttribute(name: "header_ownerid"): Xrm.Attributes.LookupAttribute;
		getControl(name: "header_ownerid"): Xrm.Controls.LookupControl;
		ui: ContactFormUI;
	}
	interface ContactFormUI {
		controls: ContactFormUIControls;
		tabs: ContactFormUITabs;
	}
	interface ContactFormUIControls  {
		get(name: string): void;
		get(name: "fullname"): Xrm.Controls.StringControl;
		get(name: "jobtitle"): Xrm.Controls.StringControl;
		get(name: "parentcustomerid"): Xrm.Controls.LookupControl;
		get(name: "emailaddress1"): Xrm.Controls.StringControl;
		get(name: "telephone1"): Xrm.Controls.StringControl;
		get(name: "mobilephone"): Xrm.Controls.StringControl;
		get(name: "fax"): Xrm.Controls.StringControl;
		get(name: "parentcustomerid"): Xrm.Controls.LookupControl;
		get(name: "contactquickform"): Xrm.Controls.LookupControl;
		get(name: "spousesname"): Xrm.Controls.StringControl;
		get(name: "birthdate"): Xrm.Controls.DateControl;
		get(name: "anniversary"): Xrm.Controls.DateControl;
		get(name: "originatingleadid"): Xrm.Controls.LookupControl;
		get(name: "lastusedincampaign"): Xrm.Controls.DateControl;
		get(name: "donotsendmm"): Xrm.Controls.BooleanControl;
		get(name: "donotemail"): Xrm.Controls.BooleanControl;
		get(name: "followemail"): Xrm.Controls.BooleanControl;
		get(name: "donotbulkemail"): Xrm.Controls.BooleanControl;
		get(name: "donotphone"): Xrm.Controls.BooleanControl;
		get(name: "donotfax"): Xrm.Controls.BooleanControl;
		get(name: "donotpostalmail"): Xrm.Controls.BooleanControl;
		get(name: "transactioncurrencyid"): Xrm.Controls.LookupControl;
		get(name: "creditlimit"): Xrm.Controls.NumberControl;
		get(name: "creditonhold"): Xrm.Controls.BooleanControl;
		get(name: "header_ownerid"): Xrm.Controls.LookupControl;
	}
	interface ContactFormUITabs  {
		get(name: string): void;
		get(name: "SUMMARY_TAB"): ContactFormUITab0;
		get(name: "DETAILS_TAB"): ContactFormUITab1;
	}
	interface ContactFormUITab0 extends Xrm.Controls.UiStandardElement, Xrm.Controls.UiFocusable {
		sections: ContactFormUITab0Sections;
	}
	interface ContactFormUITab1 extends Xrm.Controls.UiStandardElement, Xrm.Controls.UiFocusable {
		sections: ContactFormUITab1Sections;
	}
	interface ContactFormUITab0Sections {
		get(name: string): void;
		get(name: "CONTACT_INFORMATION"): Xrm.Controls.Section;
		get(name: "MapSection"): Xrm.Controls.Section;
		get(name: "SOCIAL_PANE_TAB"): Xrm.Controls.Section;
		get(name: "CUSTOMER_DETAILS_TAB"): Xrm.Controls.Section;
	}
	interface ContactFormUITab1Sections {
		get(name: string): void;
		get(name: "PERSONAL INFORMATION"): Xrm.Controls.Section;
		get(name: "PERSONAL_NOTES_SECTION"): Xrm.Controls.Section;
		get(name: "marketing information"): Xrm.Controls.Section;
		get(name: "CONTACT_PREFERENCES"): Xrm.Controls.Section;
		get(name: "billing information"): Xrm.Controls.Section;
		get(name: "shipping information"): Xrm.Controls.Section;
	}
}
