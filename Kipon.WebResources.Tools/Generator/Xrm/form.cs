using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipon.WebResources.Tools.Generator.Xrm
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class form
    {

        private formAncestor ancestorField;

        private formData[] hiddencontrolsField;

        private formTab[] tabsField;

        private formHeader headerField;

        private formClientresources clientresourcesField;

        private formNavigation navigationField;

        private formDisplayConditions displayConditionsField;

        private bool showImageField;

        /// <remarks/>
        public formAncestor ancestor
        {
            get
            {
                return this.ancestorField;
            }
            set
            {
                this.ancestorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("data", IsNullable = false)]
        public formData[] hiddencontrols
        {
            get
            {
                return this.hiddencontrolsField;
            }
            set
            {
                this.hiddencontrolsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("tab", IsNullable = false)]
        public formTab[] tabs
        {
            get
            {
                return this.tabsField;
            }
            set
            {
                this.tabsField = value;
            }
        }

        /// <remarks/>
        public formHeader header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public formClientresources clientresources
        {
            get
            {
                return this.clientresourcesField;
            }
            set
            {
                this.clientresourcesField = value;
            }
        }

        /// <remarks/>
        public formNavigation Navigation
        {
            get
            {
                return this.navigationField;
            }
            set
            {
                this.navigationField = value;
            }
        }

        /// <remarks/>
        public formDisplayConditions DisplayConditions
        {
            get
            {
                return this.displayConditionsField;
            }
            set
            {
                this.displayConditionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showImage
        {
            get
            {
                return this.showImageField;
            }
            set
            {
                this.showImageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formAncestor
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formData
    {

        private string idField;

        private string datafieldnameField;

        private string classidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datafieldname
        {
            get
            {
                return this.datafieldnameField;
            }
            set
            {
                this.datafieldnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string classid
        {
            get
            {
                return this.classidField;
            }
            set
            {
                this.classidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTab
    {

        private formTabColumn[] columnsField;

        private string nameField;

        private string idField;

        private byte isUserDefinedField;

        private bool showlabelField;

        private bool expandedField;

        private byte locklevelField;

        private bool locklevelFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
        public formTabColumn[] columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte IsUserDefined
        {
            get
            {
                return this.isUserDefinedField;
            }
            set
            {
                this.isUserDefinedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool expanded
        {
            get
            {
                return this.expandedField;
            }
            set
            {
                this.expandedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte locklevel
        {
            get
            {
                return this.locklevelField;
            }
            set
            {
                this.locklevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locklevelSpecified
        {
            get
            {
                return this.locklevelFieldSpecified;
            }
            set
            {
                this.locklevelFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumn
    {

        private formTabColumnSection[] sectionsField;

        private string widthField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("section", IsNullable = false)]
        public formTabColumnSection[] sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSection
    {

        private formTabColumnSectionRow[] rowsField;

        private string nameField;

        private bool showlabelField;

        private bool showbarField;

        private string idField;

        private byte isUserDefinedField;

        private string layoutField;

        private byte columnsField;

        private byte labelwidthField;

        private string celllabelpositionField;

        private byte locklevelField;

        private bool locklevelFieldSpecified;

        private string celllabelalignmentField;

        private string heightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public formTabColumnSectionRow[] rows
        {
            get
            {
                return this.rowsField;
            }
            set
            {
                this.rowsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showbar
        {
            get
            {
                return this.showbarField;
            }
            set
            {
                this.showbarField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte IsUserDefined
        {
            get
            {
                return this.isUserDefinedField;
            }
            set
            {
                this.isUserDefinedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string layout
        {
            get
            {
                return this.layoutField;
            }
            set
            {
                this.layoutField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte labelwidth
        {
            get
            {
                return this.labelwidthField;
            }
            set
            {
                this.labelwidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelposition
        {
            get
            {
                return this.celllabelpositionField;
            }
            set
            {
                this.celllabelpositionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte locklevel
        {
            get
            {
                return this.locklevelField;
            }
            set
            {
                this.locklevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locklevelSpecified
        {
            get
            {
                return this.locklevelFieldSpecified;
            }
            set
            {
                this.locklevelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelalignment
        {
            get
            {
                return this.celllabelalignmentField;
            }
            set
            {
                this.celllabelalignmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRow
    {

        private formTabColumnSectionRowCell cellField;

        private string heightField;

        /// <remarks/>
        public formTabColumnSectionRowCell cell
        {
            get
            {
                return this.cellField;
            }
            set
            {
                this.cellField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCell
    {

        private formTabColumnSectionRowCellEvents eventsField;

        private formTabColumnSectionRowCellControl controlField;

        private string idField;

        private bool showlabelField;

        private bool showlabelFieldSpecified;

        private byte locklevelField;

        private bool locklevelFieldSpecified;

        private byte rowspanField;

        private bool rowspanFieldSpecified;

        private byte colspanField;

        private bool colspanFieldSpecified;

        private bool autoField;

        private bool autoFieldSpecified;

        private bool userspacerField;

        private bool userspacerFieldSpecified;

        /// <remarks/>
        public formTabColumnSectionRowCellEvents events
        {
            get
            {
                return this.eventsField;
            }
            set
            {
                this.eventsField = value;
            }
        }

        /// <remarks/>
        public formTabColumnSectionRowCellControl control
        {
            get
            {
                return this.controlField;
            }
            set
            {
                this.controlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool showlabelSpecified
        {
            get
            {
                return this.showlabelFieldSpecified;
            }
            set
            {
                this.showlabelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte locklevel
        {
            get
            {
                return this.locklevelField;
            }
            set
            {
                this.locklevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locklevelSpecified
        {
            get
            {
                return this.locklevelFieldSpecified;
            }
            set
            {
                this.locklevelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte rowspan
        {
            get
            {
                return this.rowspanField;
            }
            set
            {
                this.rowspanField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rowspanSpecified
        {
            get
            {
                return this.rowspanFieldSpecified;
            }
            set
            {
                this.rowspanFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte colspan
        {
            get
            {
                return this.colspanField;
            }
            set
            {
                this.colspanField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool colspanSpecified
        {
            get
            {
                return this.colspanFieldSpecified;
            }
            set
            {
                this.colspanFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool auto
        {
            get
            {
                return this.autoField;
            }
            set
            {
                this.autoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool autoSpecified
        {
            get
            {
                return this.autoFieldSpecified;
            }
            set
            {
                this.autoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool userspacer
        {
            get
            {
                return this.userspacerField;
            }
            set
            {
                this.userspacerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool userspacerSpecified
        {
            get
            {
                return this.userspacerFieldSpecified;
            }
            set
            {
                this.userspacerFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCellEvents
    {

        private formTabColumnSectionRowCellEventsEvent eventField;

        /// <remarks/>
        public formTabColumnSectionRowCellEventsEvent @event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCellEventsEvent
    {

        private formTabColumnSectionRowCellEventsEventInternalHandlers internalHandlersField;

        private string nameField;

        private bool applicationField;

        private bool activeField;

        /// <remarks/>
        public formTabColumnSectionRowCellEventsEventInternalHandlers InternalHandlers
        {
            get
            {
                return this.internalHandlersField;
            }
            set
            {
                this.internalHandlersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool application
        {
            get
            {
                return this.applicationField;
            }
            set
            {
                this.applicationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool active
        {
            get
            {
                return this.activeField;
            }
            set
            {
                this.activeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCellEventsEventInternalHandlers
    {

        private formTabColumnSectionRowCellEventsEventInternalHandlersHandler handlerField;

        /// <remarks/>
        public formTabColumnSectionRowCellEventsEventInternalHandlersHandler Handler
        {
            get
            {
                return this.handlerField;
            }
            set
            {
                this.handlerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCellEventsEventInternalHandlersHandler
    {

        private string functionNameField;

        private string libraryNameField;

        private string handlerUniqueIdField;

        private bool enabledField;

        private bool passExecutionContextField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string functionName
        {
            get
            {
                return this.functionNameField;
            }
            set
            {
                this.functionNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string libraryName
        {
            get
            {
                return this.libraryNameField;
            }
            set
            {
                this.libraryNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string handlerUniqueId
        {
            get
            {
                return this.handlerUniqueIdField;
            }
            set
            {
                this.handlerUniqueIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool passExecutionContext
        {
            get
            {
                return this.passExecutionContextField;
            }
            set
            {
                this.passExecutionContextField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCellControl
    {

        private formTabColumnSectionRowCellControlParameters parametersField;

        private string idField;

        private string classidField;

        private string datafieldnameField;

        private bool disabledField;

        private bool disabledFieldSpecified;

        /// <remarks/>
        public formTabColumnSectionRowCellControlParameters parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string classid
        {
            get
            {
                return this.classidField;
            }
            set
            {
                this.classidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datafieldname
        {
            get
            {
                return this.datafieldnameField;
            }
            set
            {
                this.datafieldnameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool disabled
        {
            get
            {
                return this.disabledField;
            }
            set
            {
                this.disabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool disabledSpecified
        {
            get
            {
                return this.disabledFieldSpecified;
            }
            set
            {
                this.disabledFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formTabColumnSectionRowCellControlParameters
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AddressField", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("AllowFilterOff", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("AutoExpand", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("AutoResolve", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("ChartGridMode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ControlMode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("DefaultViewId", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("DependentAttributeName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("DependentAttributeType", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("DisableMru", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("DisableQuickFind", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("DisableViewPicker", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("EnableChartPicker", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("EnableContextualActions", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("EnableJumpBar", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("EnableQuickFind", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("EnableViewPicker", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("FilterRelationshipName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("IsUserChart", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("IsUserView", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("QuickForms", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("RecordsPerPage", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("RelationshipName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("TargetEntityType", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ViewId", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ViewIds", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("VisualizationId", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        AddressField,

        /// <remarks/>
        AllowFilterOff,

        /// <remarks/>
        AutoExpand,

        /// <remarks/>
        AutoResolve,

        /// <remarks/>
        ChartGridMode,

        /// <remarks/>
        ControlMode,

        /// <remarks/>
        DefaultViewId,

        /// <remarks/>
        DependentAttributeName,

        /// <remarks/>
        DependentAttributeType,

        /// <remarks/>
        DisableMru,

        /// <remarks/>
        DisableQuickFind,

        /// <remarks/>
        DisableViewPicker,

        /// <remarks/>
        EnableChartPicker,

        /// <remarks/>
        EnableContextualActions,

        /// <remarks/>
        EnableJumpBar,

        /// <remarks/>
        EnableQuickFind,

        /// <remarks/>
        EnableViewPicker,

        /// <remarks/>
        FilterRelationshipName,

        /// <remarks/>
        IsUserChart,

        /// <remarks/>
        IsUserView,

        /// <remarks/>
        QuickForms,

        /// <remarks/>
        RecordsPerPage,

        /// <remarks/>
        RelationshipName,

        /// <remarks/>
        TargetEntityType,

        /// <remarks/>
        ViewId,

        /// <remarks/>
        ViewIds,

        /// <remarks/>
        VisualizationId,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formHeader
    {

        private formHeaderRows rowsField;

        private string idField;

        private byte columnsField;

        private string celllabelpositionField;

        private byte labelwidthField;

        /// <remarks/>
        public formHeaderRows rows
        {
            get
            {
                return this.rowsField;
            }
            set
            {
                this.rowsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string celllabelposition
        {
            get
            {
                return this.celllabelpositionField;
            }
            set
            {
                this.celllabelpositionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte labelwidth
        {
            get
            {
                return this.labelwidthField;
            }
            set
            {
                this.labelwidthField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formHeaderRows
    {

        private formHeaderRowsCell[] rowField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("cell", IsNullable = false)]
        public formHeaderRowsCell[] row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formHeaderRowsCell
    {

        private formHeaderRowsCellControl controlField;

        private string idField;

        private bool showlabelField;

        private bool showlabelFieldSpecified;

        private byte locklevelField;

        private bool locklevelFieldSpecified;

        /// <remarks/>
        public formHeaderRowsCellControl control
        {
            get
            {
                return this.controlField;
            }
            set
            {
                this.controlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool showlabel
        {
            get
            {
                return this.showlabelField;
            }
            set
            {
                this.showlabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool showlabelSpecified
        {
            get
            {
                return this.showlabelFieldSpecified;
            }
            set
            {
                this.showlabelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte locklevel
        {
            get
            {
                return this.locklevelField;
            }
            set
            {
                this.locklevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool locklevelSpecified
        {
            get
            {
                return this.locklevelFieldSpecified;
            }
            set
            {
                this.locklevelFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formHeaderRowsCellControl
    {

        private string idField;

        private string classidField;

        private string datafieldnameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string classid
        {
            get
            {
                return this.classidField;
            }
            set
            {
                this.classidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datafieldname
        {
            get
            {
                return this.datafieldnameField;
            }
            set
            {
                this.datafieldnameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formClientresources
    {

        private formClientresourcesInternalresources internalresourcesField;

        /// <remarks/>
        public formClientresourcesInternalresources internalresources
        {
            get
            {
                return this.internalresourcesField;
            }
            set
            {
                this.internalresourcesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formClientresourcesInternalresources
    {

        private formClientresourcesInternalresourcesClientincludes clientincludesField;

        /// <remarks/>
        public formClientresourcesInternalresourcesClientincludes clientincludes
        {
            get
            {
                return this.clientincludesField;
            }
            set
            {
                this.clientincludesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formClientresourcesInternalresourcesClientincludes
    {

        private formClientresourcesInternalresourcesClientincludesInternaljscriptfile internaljscriptfileField;

        /// <remarks/>
        public formClientresourcesInternalresourcesClientincludesInternaljscriptfile internaljscriptfile
        {
            get
            {
                return this.internaljscriptfileField;
            }
            set
            {
                this.internaljscriptfileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formClientresourcesInternalresourcesClientincludesInternaljscriptfile
    {

        private string srcField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string src
        {
            get
            {
                return this.srcField;
            }
            set
            {
                this.srcField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formNavigation
    {

        private formNavigationNavBarByRelationshipItem[] navBarField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("NavBarByRelationshipItem", IsNullable = false)]
        public formNavigationNavBarByRelationshipItem[] NavBar
        {
            get
            {
                return this.navBarField;
            }
            set
            {
                this.navBarField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formNavigationNavBarByRelationshipItem
    {

        private formNavigationNavBarByRelationshipItemPrivileges privilegesField;

        private formNavigationNavBarByRelationshipItemTitles titlesField;

        private string relationshipNameField;

        private string idField;

        private ushort sequenceField;

        private string areaField;

        private bool showField;

        private string titleResourceIdField;

        /// <remarks/>
        public formNavigationNavBarByRelationshipItemPrivileges Privileges
        {
            get
            {
                return this.privilegesField;
            }
            set
            {
                this.privilegesField = value;
            }
        }

        /// <remarks/>
        public formNavigationNavBarByRelationshipItemTitles Titles
        {
            get
            {
                return this.titlesField;
            }
            set
            {
                this.titlesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RelationshipName
        {
            get
            {
                return this.relationshipNameField;
            }
            set
            {
                this.relationshipNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Sequence
        {
            get
            {
                return this.sequenceField;
            }
            set
            {
                this.sequenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Area
        {
            get
            {
                return this.areaField;
            }
            set
            {
                this.areaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Show
        {
            get
            {
                return this.showField;
            }
            set
            {
                this.showField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TitleResourceId
        {
            get
            {
                return this.titleResourceIdField;
            }
            set
            {
                this.titleResourceIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formNavigationNavBarByRelationshipItemPrivileges
    {

        private formNavigationNavBarByRelationshipItemPrivilegesPrivilege privilegeField;

        /// <remarks/>
        public formNavigationNavBarByRelationshipItemPrivilegesPrivilege Privilege
        {
            get
            {
                return this.privilegeField;
            }
            set
            {
                this.privilegeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formNavigationNavBarByRelationshipItemPrivilegesPrivilege
    {

        private string entityField;

        private string privilegeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Entity
        {
            get
            {
                return this.entityField;
            }
            set
            {
                this.entityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Privilege
        {
            get
            {
                return this.privilegeField;
            }
            set
            {
                this.privilegeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formNavigationNavBarByRelationshipItemTitles
    {

        private formNavigationNavBarByRelationshipItemTitlesTitle titleField;

        /// <remarks/>
        public formNavigationNavBarByRelationshipItemTitlesTitle Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formNavigationNavBarByRelationshipItemTitlesTitle
    {

        private ushort lCIDField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort LCID
        {
            get
            {
                return this.lCIDField;
            }
            set
            {
                this.lCIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formDisplayConditions
    {

        private object everyoneField;

        private bool fallbackFormField;

        private byte orderField;

        /// <remarks/>
        public object Everyone
        {
            get
            {
                return this.everyoneField;
            }
            set
            {
                this.everyoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool FallbackForm
        {
            get
            {
                return this.fallbackFormField;
            }
            set
            {
                this.fallbackFormField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }
    }


}
