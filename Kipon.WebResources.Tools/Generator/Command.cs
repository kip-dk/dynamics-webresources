using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipon.WebResources.Tools.Generator
{
    public class Command
    {
        public void Run(string definitionfile)
        {
            var forms = Kipon.WebResources.Tools.Generator.Config.forms.GetFromXmlFile(definitionfile);
            foreach (var form in forms.form)
            {
            }
        }
    }
}
