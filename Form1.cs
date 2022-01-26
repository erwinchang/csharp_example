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

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtW.Multiline = true;
            TxtW.Dock = DockStyle.Fill;
            MnuStyle1.CheckOnClick = true;
            MnuStyle2.CheckOnClick = true;
            MnuSet2.CheckOnClick = true;
            MnuSet1_Click(sender, e);
        }

        private void MnuStyle_Click(object sender, EventArgs e)
        {

        }

        private void MnuSet1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test11");
        }
    }
}
