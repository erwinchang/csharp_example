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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adaptee adaptee = new Adaptee();
            adaptee.fileName = "test.xls";
            adaptee.SpecificRequest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iTarget target = new Adapter();
            target.fileName = "test.xls";
            target.Request();
        }
    }
}
