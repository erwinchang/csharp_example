using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class PadClass
    {
        private int price = 25900;
        public int Price
        {
            get { return price; }
            set {
                if (value < 0) value = 0;
                price = value; 
            }
        }
    }
}
