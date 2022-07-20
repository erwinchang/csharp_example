using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        Thread fillListThread;
        CTextOutput ctoFillList;
        public Form1()
        {
            InitializeComponent();
            ctoFillList = new CTextOutput(this, "default");
        }

        private delegate void AddTextDelegate(string text);
        public void AddText(string text)
        {
            if (ltbViewText.InvokeRequired)
            {
                AddTextDelegate td = AddText;
                ltbViewText.Invoke(td, text);
            }
            else
            {
                ltbViewText.Items.Add(text);
            }
        }

        private void btnStartThread_Click(object sender, EventArgs e)
        {
            ltbViewText.Items.Clear();
            ctoFillList.shouldstop = false;
            ctoFillList.strOutputText = tbText.Text;
            fillListThread = new Thread(ctoFillList.WriteText);
            fillListThread.IsBackground = true;
            fillListThread.Start();
        }

        private void btnEndThread_Click(object sender, EventArgs e)
        {
            ctoFillList.shouldstop = true;
            Console.WriteLine("wait fillListThread..");
            fillListThread.Join(0);
            Console.WriteLine("finish..");
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            ctoFillList.strOutputText = tbText.Text;
        }
    }
}
