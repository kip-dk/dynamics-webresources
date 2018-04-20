using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipon.WebResources.Tools.Deploy
{
    public class Merge
    {

        private const string INCLUDE_REF = "//#include";

        private string path = null;
        public Merge(string path)
        {
            this.path = path;
        }


        public bool IsChanged(string file, System.DateTime lastChange)
        {
            return this.DoIsChanged(file, lastChange, false);
        }

        private bool DoIsChanged(string file, System.DateTime lastChange, bool nested = false)
        {
            var alllines = (from l in System.IO.File.ReadLines(file) select l).ToArray();
            if ((new FileInfo(file).LastWriteTimeUtc > lastChange))
            {
                return true;
            }

            var includes = (from l in alllines where l.StartsWith(INCLUDE_REF) select l.Split(' ')[1]).ToArray();



            foreach (var include in includes)
            {
                var name = path + include;
                var changed = DoIsChanged(name, lastChange, true);
                if (changed)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MergeOnly(string file)
        {
            var alllines = (from l in System.IO.File.ReadLines(file) select l).ToArray();
            var alwaysmerge = (from l in alllines where l.Contains("//merge: always") select l).Any();
            if (alwaysmerge)
            {
                return true;
            }
            return false;
        }

        public string DeployName(string file, string defaultname)
        {
            var alllines = (from l in System.IO.File.ReadLines(file) select l).ToArray();
            var deploy = (from l in alllines where l.StartsWith("//deploy:") select l).FirstOrDefault();

            if (!string.IsNullOrEmpty(deploy))
            {
                var index = deploy.IndexOf(':');
                return deploy.Substring(index + 1).Trim();
            }
            return defaultname;
        }

        public byte[] GetMergedFileContent(string file, ResourceTypeEnum type)
        {
            if (type == ResourceTypeEnum.Jscript)
            {
                var sb = new StringBuilder();
                var lines = System.IO.File.ReadAllLines(file);
                AddLines(sb, lines);
                return Encoding.UTF8.GetBytes(sb.ToString());
            } else
            {
                return System.IO.File.ReadAllBytes(file);
            }
        }

        private void AddLines(StringBuilder sb, string[] lines)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith(INCLUDE_REF))
                {
                    var file = line.Split(' ')[1].Trim();
                    sb.Append("// Start include " + file + "\n");
                    var subFileLines = System.IO.File.ReadAllLines(path + file);
                    AddLines(sb, subFileLines);
                    sb.Append("// End include " + file + "\n");

                }
                else
                {
                    sb.Append(line + "\n");
                }
            }
        }
    }
}
