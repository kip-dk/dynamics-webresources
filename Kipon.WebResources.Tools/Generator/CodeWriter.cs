using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipon.WebResources.Tools.Generator
{
    public class CodeWriter : IDisposable
    {
        private System.IO.StreamWriter writer;

        public int indent = 0;

        public CodeWriter(string filename)
        {
            this.writer = new System.IO.StreamWriter(filename);
        }


        public void Writeline(string code)
        {
            if (code.Contains('}')) indent--;
            for (var i=0;i<indent;i++)
            {
                writer.Write("\t");
            }
            writer.WriteLine(code);
            if (code.Contains('{')) indent++;
        }

        public void Dispose()
        {
            writer.Close();
        }
    }
}
