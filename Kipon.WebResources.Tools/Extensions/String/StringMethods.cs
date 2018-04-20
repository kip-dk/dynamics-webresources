using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipon.WebResources.Tools.Extensions.String
{
    public static class StringMethods
    {
        public static string GetParameter(this string[] args, string name, bool required = false)
        {
            if (args == null || args.Length == 0)
            {
                if (required) throw new ArgumentException("expected parameter /"  + name  );
                return null;
            }
            var param = (from p in args where p.StartsWith("/" + name + ":") select p).SingleOrDefault();
            if (param != null)
            {
                var index = param.IndexOf(':');
                return param.Substring(index + 1);
            }

            if (required) throw new ArgumentException("expected parameter /" + name);
            return null;
        }

        public static Deploy.ResourceTypeEnum ToResourceType(this string filename)
        {
            var upperExtension = filename.ToUpper().Split('.').Last();

            switch (upperExtension)
            {
                case "HTM":
                case "HTML": return Deploy.ResourceTypeEnum.Html;
                case "CSS": return Deploy.ResourceTypeEnum.Css;
                case "JS": return Deploy.ResourceTypeEnum.Jscript;
                case "XML": return Deploy.ResourceTypeEnum.Xml;
                case "PNG": return Deploy.ResourceTypeEnum.Png;
                case "JPEG":
                case "JPG": return Deploy.ResourceTypeEnum.Jpg;
                case "GIF": return Deploy.ResourceTypeEnum.Gif;
                case "XAP": return Deploy.ResourceTypeEnum.Xap;
                case "XLS": return Deploy.ResourceTypeEnum.Xsl;
                case "XSLT": return Deploy.ResourceTypeEnum.Xsl;
                case "ICO": return Deploy.ResourceTypeEnum.Ico;
            }
            return Deploy.ResourceTypeEnum.Unknown;
        }

        public static byte[] DefaultContentForEmplyFile(this string filename)
        {
            var type = filename.ToResourceType();
            switch (type)
            {
                case Deploy.ResourceTypeEnum.Html: return System.Text.Encoding.ASCII.GetBytes("<!-- Empty html file -->");
                case Deploy.ResourceTypeEnum.Css: return System.Text.Encoding.ASCII.GetBytes("/* Empty css file */");
                case Deploy.ResourceTypeEnum.Jscript: return System.Text.Encoding.ASCII.GetBytes("/* Empty javascript file */");
            }
            return new byte[0];
        }
    }
}
