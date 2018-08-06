using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Description;
using Kipon.WebResources.Tools.Extensions.String;

namespace Kipon.WebResources.Tools.Deploy
{
    public class Command
    {
        public static void Run(string[] args)
        {
            try
            {
                var url = args.GetParameter("url", true);
                var prefix = args.GetParameter("prefix", true);
                var solution = args.GetParameter("solution", false);

                IOrganizationService service = Kipon.WebResources.Tools.Service.Factory.GetOrganizationService(args);

                Console.WriteLine("Deploy scripts to: " + url);

                var path = @"Scripts\";
                var merge = new Deploy.Merge(path);
                UploadDirectory(service, path, prefix, ".js", merge, null, solution);

                path = @"HTML\";
                merge = new Deploy.Merge(path);
                UploadDirectory(service, path, prefix, ".html", merge, null, solution);

                path = @"CSS\";
                merge = new Deploy.Merge(path);
                UploadDirectory(service, path, prefix, ".css", merge, null, solution);

                path = @"Icons\";
                merge = new Deploy.Merge(path);
                UploadDirectory(service, path, prefix, null, merge, null, solution);

                Console.WriteLine("Uploade done - press [ENTER]");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Usage: Kipon.WebResources.Tools deploy /url:url /user:user /password:password /prefix:prefix /solution:solution");
            }
        }

        private static void UploadDirectory(IOrganizationService service, string path, string prefix, string extension, Deploy.Merge merge, string subpath, string solution)
        {
            Console.WriteLine("Upload " + path);

            foreach (var file in Directory.GetFiles(path))
            {
                var filename = Path.GetFileName(file);

                if (file.ToUpper().EndsWith(".MAP") || file.ToUpper().EndsWith(".TS"))
                {
                    continue;
                }

                if (subpath == null)
                {
                    filename = prefix + "_" + filename;
                }
                else
                {
                    filename = prefix + "_" + "/" + subpath + "/" + filename;
                }

                filename = filename.Replace(@"\", "/");
                filename = merge.DeployName(file, filename);

                var webResource = findWebresource(service, filename, extension);
                var type = filename.ToResourceType();

                if (webResource != null)
                {
                    var lastChange = ((DateTime)webResource["modifiedon"]).ToUniversalTime();

                    if (merge.IsChanged(file, lastChange))
                    {
                        Console.WriteLine("Updating " + filename);

                        webResource["content"] = Convert.ToBase64String(merge.GetMergedFileContent(file, type));
                        service.Update(webResource);

                        var publishRequest = new PublishXmlRequest
                        {
                            ParameterXml = string.Format("<importexportxml><webresources><webresource>{0}</webresource></webresources></importexportxml>", webResource.Id)
                        };

                        var res = service.Execute(publishRequest) as PublishXmlResponse;
                        if (res != null)
                        {
                            foreach (var re in res.Results)
                            {
                                Console.WriteLine(re.Key + " " + re.Value);
                            }
                        }
                    }
                }
                else
                {
                    if (merge.MergeOnly(file))
                    {
                        continue;
                    }

                    webResource = new Entity
                    {
                        Id = Guid.NewGuid(),
                        LogicalName = "webresource"
                    };
                    webResource["name"] = filename;
                    webResource["content"] = Convert.ToBase64String(merge.GetMergedFileContent(file, type));
                    webResource["displayname"] = filename;
                    webResource["description"] = "Auto Imported as part";

                    if (type == ResourceTypeEnum.Unknown)
                    {
                        Console.WriteLine("Warning : unable to map file to Dynamics 365 web resource type " + filename + ". The file was ignored");
                        continue;
                    }
                    webResource["webresourcetype"] = new Microsoft.Xrm.Sdk.OptionSetValue((int)type);
                    service.Create(webResource);

                    var publishRequest = new PublishXmlRequest
                    {
                        ParameterXml = string.Format("<importexportxml><webresources><webresource>{0}</webresource></webresources></importexportxml>", webResource.Id)
                    };
                    service.Execute(publishRequest);

                    if (!string.IsNullOrEmpty(solution))
                    {
                        // attach new webResource to solution
                        var request = new Microsoft.Crm.Sdk.Messages.AddSolutionComponentRequest
                        {
                            ComponentType = 61, // Web Resource,
                            ComponentId = webResource.Id,
                            SolutionUniqueName = solution
                        };
                        service.Execute(request);
                    }
                    Console.WriteLine("Created " + filename);

                }
            }

            foreach (var dir in Directory.GetDirectories(path))
            {
                var d = dir.Replace(path, "");

                if (!string.IsNullOrEmpty(subpath))
                {
                    d = subpath + @"\" + d;
                }
                UploadDirectory(service, dir, prefix, extension, merge, d, solution);
            }

        }

        private static Entity findWebresource(IOrganizationService service, string filename, string extension)
        {
            var query = new QueryExpression("webresource");
            query.ColumnSet = new ColumnSet(true);
            query.Criteria.AddCondition("name", ConditionOperator.Equal, filename);

            var res = service.RetrieveMultiple(query);
            var result = res.Entities.SingleOrDefault();

            if (result != null)
            {
                return result;
            }
            else
            {
                if (extension != null && filename.EndsWith(extension))
                {
                    var newfilename = filename.Substring(0, filename.Length - extension.Length);
                    return findWebresource(service, newfilename, null);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
