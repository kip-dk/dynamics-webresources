using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Description;
using Kipon.WebResources.Tools.Extensions.String;


namespace Kipon.WebResources.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0 )
            {
                Console.WriteLine("Usage: Kipon.WebResources.Tools [deploy | generate] /url:url /user:user /password:password /prefix:prefix /solution:solution");
                return;
            }

            switch (args[0].ToLower())
            {
                case "deploy":
                    {
                        Kipon.WebResources.Tools.Deploy.Command.Run(args.Skip(1).ToArray());
                        break;
                    }
                case "generate":
                    {
                        Kipon.WebResources.Tools.Generator.Command.Run(args.Skip(1).ToArray());
                        break;
                    }
                default:
                    {
                        Console.WriteLine("First argument must be one of the following:  deploy | generate");
                        break;
                    }
            }


        }
    }
}
