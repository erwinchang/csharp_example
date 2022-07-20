using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyExample
    {
    }
    public class CTextOutput
    {
        public volatile bool shouldstop = false;
        public volatile string strOutputText;
        private Form1 form1;

        public CTextOutput(Form1 form1,string strText)
        {
            this.form1 = form1;
            strOutputText = strText;
        }
        public void WriteText()
        {
            form1.AddText(strOutputText);
            while(shouldstop == false)
            {
                Thread.Sleep(100);
                form1.AddText(strOutputText);
            }
            form1.AddText("Auto Fill Close..");
        }
    }
}
