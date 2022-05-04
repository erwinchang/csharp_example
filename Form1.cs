using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.notifyicon?view=netframework-4.8
        //private System.Windows.Forms.NotifyIcon notifyIcon1;
        //private System.Windows.Forms.ContextMenu contextMenu1;
        //private System.Windows.Forms.MenuItem menuItem1;
        //private System.ComponentModel.IContainer components;

        public Form1()
        {
            InitializeComponent();
            //this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            //this.menuItem1 = new System.Windows.Forms.MenuItem();
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
