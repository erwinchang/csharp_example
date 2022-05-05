using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram
    {
    }
    class haha
    {
        string name;
        string detail;
        public haha(string name, string detail)
        {
            this.name = name;
            this.detail = detail;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        static internal List<haha> GET()
        {
            haha item = new haha("zeko", "dunno");
            haha xx = new haha("sheshe", "dunno");
            haha ww = new haha("murhaf", "dunno");
            haha qq = new haha("soz", "dunno");
            haha ee = new haha("HELLO", "dunno");
            List<haha> x = new List<haha>();
            x.Add(item);
            x.Add(xx);
            x.Add(ww);
            x.Add(qq);
            x.Add(ee);
            return x;
        }
    }
}
