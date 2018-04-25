declare module XrmForm {
    interface AttributeEmpty {
    }

    interface Attribute<T> extends AttributeEmpty {
        controls: XrmPage.Lists.List<XrmPage.Controls.AttributeControl<Attribute<T>>>;
        getValue(): T;
        setValue(val: T): void;
        getAttributeType(): string;
        getFormat(): string;
        getIsDirty(): boolean;
        getIsPartyList(): boolean;
        getMaxLength(): number;
        getName(): string;
        getParent(): XrmPage.Data.PageEntity;
        getUserPrivilege(): XrmPage.Objects.UserPrivilege;
        addOnChange(functionRef: (context?: XrmPage.Objects.ExecutionContext) => any);
        removeOnChange(functionRef: Function);
        fireOnChange();
        getRequiredLevel(): string;
        setRequiredLevel(level: "none");
        setRequiredLevel(level: "required");
        setRequiredLevel(level: "recommended");
        setRequiredLevel(level: string);
        getSubmitMode(): string;
        setSubmitMode(mode: "always");
        setSubmitMode(mode: "never");
        setSubmitMode(mode: "dirty");
        setSubmitMode(mode: string);
    }

    interface AttributeNumber extends Attribute<number> {
        getMax(): number;
        getMin(): number;
        getPrecision(): number;
    }

    interface AttributeLookup extends Attribute<Xrm.LookupValue[]> {
    }

    interface OptionSetAttribute extends Attribute<Xrm.OptionSetValue> {
        getInitialValue(): number;
        getText(): string;
        getOption(value: string): Xrm.OptionSetValue;
        getOption(value: number): Xrm.OptionSetValue;
        getOptions(): Xrm.OptionSetValue[];
        getSelectedOption(): Xrm.OptionSetValue;
    }


    interface EmptyControl {
    }

    interface BaseControl extends EmptyControl {
        getControlType(): string;
        setFocus();
        getParent(): XrmPage.XrmFormSection;
        getName(): string;
        getLabel(): string;
        setLabel(label: string);
        getVisible(): boolean;
        setVisible(visible: boolean);
        getDisabled(): boolean;
        setDisabled(disable: boolean);
        setNotification(message: string, uniqueId: string): boolean;
        clearNotification(uniqueId: string): boolean;
        hideAutoComplete();
        showAutoComplete(object: any);
        addOnKeyPress(func: (any) => any);
        removeOnKeypress();
    }

    interface AttributeControl<T extends AttributeEmpty> extends BaseControl {
        getAttribute(): T;
    }

    interface OptionSetControl extends AttributeControl<OptionSetAttribute> {
        addOption(option: XrmPage.Objects.OptionSetValue, index?: number);
        clearOptions();
        removeOption(number: number);
    }

    interface ExternalControl extends BaseControl {
        getObject(): any;
        getSrc(): string;
        setSrc(url: string);
    }

    interface WebResourceControl extends ExternalControl {
        getData(): string;
        setData(dataQuery: string);
    }

    interface IFrameControl extends ExternalControl {
        getInitialUrl(): string;
    }

    interface DateControl extends AttributeControl<Attribute<Date>> {
        getShowTime(): boolean;
        setShowTime(doShow: boolean);
    }

    interface LookupControl extends AttributeControl<AttributeLookup> {
        addCustomFilter(fetchXml: string, entityType?: string);
        addCustomView(viewId: string, entityName: string, viewDisplayName: string, fetchXml: string, layoutXml: string, isDefault: boolean);
        getDefaultView(): string;
        setDefaultView(guid: string);
        addPreSearch(handler: Function);
        removePreSearch(handler: Function);
    }

    interface SubGridControl extends BaseControl {
        refresh();
        addOnLoad(functionRef: (context?: XrmPage.Objects.ExecutionContext) => any);
        getEntityName(): string
        getGrid(): Grid;
        getViewSelector(): ViewSelector;
        removeOnLoad(reference: Function);
    }

    interface Grid {
        getRows(): List<GridRow>;
        getSelectedRows(): List<GridRow>;
        getTotalRecordCount(): number;
    }

    interface GridRow {
        getData(): GridRowData;
    }

    interface GridRowData {
        getEntity(): GridEntity;
    }

    interface GridEntity {
        getEntityName(): string;
        getEntityReference(): Xrm.LookupValue;
        getId(): string;
        getPrimaryAttributeValue(): string;
    }

    interface ViewSelector {
        getCurrentView(): Xrm.LookupValue;
        isVisible(): boolean;
        setCurrentView(reference: Xrm.LookupValue);
    }

    interface StringControl extends AttributeControl<Attribute<string>> {
    }

    interface NumberControl extends AttributeControl<AttributeNumber> {
    }

    interface ListBase<T> {
        forEach(delegate: ListItem<T>): void;
        getLength(): number;
    }

    interface ListItem<T> {
        (item: T, index: number): any
    }

    interface List<T> extends ListBase<T> {
        get(): T[];
        get(index: number): T;
        get(name: string): T;
        get(chooser: ListPicker<T>): T[];
    }

    interface ListPicker<T> {

        (item: T, index: number): boolean;
    }
}
