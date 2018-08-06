using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Description;
using Kipon.WebResources.Tools.Extensions.String;
using System.Xml.Serialization;

namespace Kipon.WebResources.Tools.Generator
{
    public class Command
    {

        private static System.Collections.Generic.Dictionary<string, Microsoft.Xrm.Sdk.Messages.RetrieveEntityResponse> entities = new System.Collections.Generic.Dictionary<string, Microsoft.Xrm.Sdk.Messages.RetrieveEntityResponse>();

        public static void Run(string[] args)
        {
            try
            {

                var sourcefile = args.GetParameter("source", true);
                var targetfile = args.GetParameter("output", true);
                var forms = Kipon.WebResources.Tools.Generator.Config.forms.GetFromXmlFile(sourcefile);

                IOrganizationService service = Kipon.WebResources.Tools.Service.Factory.GetOrganizationService(args);

                using (var uow = new Entities.CrmUnitOfWork(service))
                {

                    using (var writer = new CodeWriter(targetfile))
                    {
                        writer.Writeline("/// <reference path=\"xrm.d.ts\" />");
                        writer.Writeline("");
                        writer.Writeline("declare namespace XrmForm {");
                        foreach (var form in forms.form)
                        {
                            var xrmEntityForm = (from f in uow.Systemforms.GetQuery()
                                           where f.ObjectTypeCode == form.entity
                                             && f.Name == form.name
                                           select f).SingleOrDefault();

                            if (xrmEntityForm == null)
                            {
                                Console.WriteLine("Entity " + form.entity + " Form " + form.name + " was not found");
                                continue;
                            }

                            Microsoft.Xrm.Sdk.Messages.RetrieveEntityResponse entity = null;
                            if (entities.ContainsKey(form.entity))
                            {
                                entity = entities[form.entity];
                            }
                            else
                            {
                                var req = new Microsoft.Xrm.Sdk.Messages.RetrieveEntityRequest
                                {
                                    RetrieveAsIfPublished = true,
                                    LogicalName = form.entity,
                                    EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes
                                };
                                entity = uow.ExecuteRequest<Microsoft.Xrm.Sdk.Messages.RetrieveEntityResponse>(req);
                                entities.Add(form.entity, entity);
                            }

                            #region XrmForm interface
                            writer.Writeline("interface " + form.asname + " {");

                            var reader = new System.IO.StringReader(xrmEntityForm.FormXml);
                            var serializer = new XmlSerializer(typeof(Kipon.WebResources.Tools.Generator.Xrm.form));

                            var xrmform = (Kipon.WebResources.Tools.Generator.Xrm.form)serializer.Deserialize(reader);

                            WriteFormControls(writer, entity, xrmform, true);

                            writer.Writeline("ui: " + form.asname + "UI;");
                            writer.Writeline("}");
                            #endregion

                            #region entity ui interface
                            writer.Writeline("interface " + form.asname + "UI {");
                            writer.Writeline("controls: " + form.asname + "UIControls;");
                            writer.Writeline("tabs: " + form.asname + "UITabs;");
                            writer.Writeline("}");
                            #endregion

                            #region controls
                            writer.Writeline("interface "+form.asname+"UIControls  {");
                            WriteFormControls(writer, entity, xrmform, false);
                            writer.Writeline("}");
                            #endregion

                            #region generate tabs
                            writer.Writeline("interface " + form.asname + "UITabs  {");
                            writer.Writeline("get(name: string): void;");
                            var ix = 0;
                            foreach (var tab in xrmform.tabs)
                            {
                                writer.Writeline("get(name: \""+tab.name+"\"): "+form.asname+"UITab"+ix.ToString()+";");
                                ix++;
                            }
                            writer.Writeline("}");

                            ix = 0;
                            foreach (var tab in xrmform.tabs)
                            {
                                writer.Writeline("interface "+form.asname+"UITab"+ix+ " extends Xrm.Controls.UiStandardElement, Xrm.Controls.UiFocusable {");
                                writer.Writeline("sections: "+form.asname+"UITab"+ix+"Sections;");
                                writer.Writeline("}");
                                ix++;
                            }

                            ix = 0;
                            foreach (var tab in xrmform.tabs)
                            {
                                writer.Writeline("interface "+form.asname+"UITab"+ix+"Sections {");
                                writer.Writeline("get(name: string): void;");

                                foreach (var col in tab.columns)
                                {
                                    foreach (var sec in col.sections)
                                    {
                                        writer.Writeline("get(name: \""+sec.name+"\"): Xrm.Controls.Section;");
                                    }
                                }
                                writer.Writeline("}");
                                ix++;
                            }
                            #endregion
                        }
                        writer.Writeline("}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Usage: Kipon.WebResources.Tools generate /url:url /user:user /password:password /source:definitionsourcefilename /output:output.d.name");
            }
        }


        private static void WriteFormControls(CodeWriter writer, Microsoft.Xrm.Sdk.Messages.RetrieveEntityResponse entity, Xrm.form xrmform, bool attributes)
        {
            if (attributes) writer.Writeline("getAttribute(name: string): void;");
            if (attributes)
            {
                writer.Writeline("getControl(name: string): void;");
            }
            else
            {
                writer.Writeline("get(name: string): void;");
            }

            foreach (var tab in xrmform.tabs)
            {
                foreach (var col in tab.columns)
                {
                    foreach (var sec in col.sections)
                    {
                        foreach (var row in sec.rows)
                        {
                            if (row.cell != null && row.cell.control != null && !string.IsNullOrEmpty(row.cell.control.datafieldname))
                            {
                                var attr = (from a in entity.EntityMetadata.Attributes where a.LogicalName == row.cell.control.datafieldname select a).Single();
                                WriteAttribute(writer, row.cell.control.id, attr.AttributeType, attributes);
                            }
                        }
                    }
                }
            }

            if (xrmform.header != null && xrmform.header.rows != null)
            {
                foreach (var cell in xrmform.header.rows.row)
                {
                    if (cell.control != null && !string.IsNullOrEmpty(cell.control.datafieldname))
                    {
                        var attr = (from a in entity.EntityMetadata.Attributes where a.LogicalName == cell.control.datafieldname select a).Single();
                        WriteAttribute(writer, cell.control.id, attr.AttributeType, attributes);
                    }
                }
            }
        }

        private static void WriteAttribute(CodeWriter writer, string id, Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode? type, bool attribute = true)
        {
            var method = "getControl";
            if (!attribute)
            {
                method = "get";
            }

            switch (type.Value)
            {
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.String:
                    {
                        if (attribute) writer.Writeline("getAttribute(name: \"" + id + "\"): Xrm.Attributes.StringAttribute;");
                        writer.Writeline(method + "(name: \"" + id + "\"): Xrm.Controls.StringControl;");
                        break;
                    }
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.BigInt:
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Decimal:
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Double:
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Money:
                    {
                        if (attribute) writer.Writeline("getAttribute(name: \"" + id + "\"): Xrm.Attributes.NumberAttribute;");
                        writer.Writeline(method + "(name: \"" + id + "\"): Xrm.Controls.NumberControl;");
                        break;
                    }
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Boolean:
                    {
                        if (attribute) writer.Writeline("getAttribute(name: \"" + id + "\"): Xrm.Attributes.BooleanAttribute;");
                        writer.Writeline(method + "(name: \"" + id + "\"): Xrm.Controls.BooleanControl;");
                        break;
                    }
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Customer:
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Lookup:
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.Owner:
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.PartyList:
                    {
                        if (attribute) writer.Writeline("getAttribute(name: \"" + id + "\"): Xrm.Attributes.LookupAttribute;");
                        writer.Writeline(method + "(name: \"" + id + "\"): Xrm.Controls.LookupControl;");
                        break;
                    }
                case Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode.DateTime:
                    {
                        if (attribute) writer.Writeline("getAttribute(name: \"" + id + "\"): Xrm.Attributes.DateAttribute;");
                        writer.Writeline(method + "(name: \"" + id + "\"): Xrm.Controls.DateControl;");
                        break;
                    }
            }
        }
    }
}
