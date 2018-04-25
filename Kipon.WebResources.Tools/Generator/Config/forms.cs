using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kipon.WebResources.Tools.Generator.Config
{
    public partial class forms
    {
        public static forms GetFromXmlFile(string file)
        {
            var ser = new XmlSerializer(typeof(forms));
            using (var reader = new System.IO.StreamReader(file))
            {
                return (forms)ser.Deserialize(reader);
            }

        }
    }
}
