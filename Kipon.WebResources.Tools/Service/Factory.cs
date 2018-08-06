using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Description;
using Kipon.WebResources.Tools.Extensions.String;

namespace Kipon.WebResources.Tools.Service
{
    public class Factory
    {
        public static IOrganizationService GetOrganizationService(string[] args)
        {
            var user = args.GetParameter("user", true);
            var pwd = args.GetParameter("password", true);
            var url = args.GetParameter("url", true);
            var prefix = args.GetParameter("prefix", true);
            var solution = args.GetParameter("solution", false);

            var credentials = new ClientCredentials();

            credentials.UserName.UserName = user;
            credentials.UserName.Password = pwd;

            var config = ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(
                new Uri(url));

            var orgService = new OrganizationServiceProxy(config, credentials);
            orgService.EnableProxyTypes();

            IOrganizationService service = (IOrganizationService)orgService;
            return service;
        }
    }
}
