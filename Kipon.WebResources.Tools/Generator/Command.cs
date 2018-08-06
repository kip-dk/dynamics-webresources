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
                            writer.Writeline("interface " + form.asname + " {");

                            var reader = new System.IO.StringReader(xrmEntityForm.FormXml);
                            var serializer = new XmlSerializer(typeof(Kipon.WebResources.Tools.Generator.Xrm.form));

                            var xrmform = (Kipon.WebResources.Tools.Generator.Xrm.form)serializer.Deserialize(reader);

                            foreach (var tab in xrmform.tabs)
                            {
                                foreach (var col in tab.columns)
                                {
                                    foreach (var sec in col.sections)
                                    {
                                        foreach (var row in sec.rows)
                                        {
                                            if (row.cell != null && row.cell.control != null && !)
                                        }
                                    }
                                }
                            }
                            


                            writer.Writeline("}");
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
    }
}
