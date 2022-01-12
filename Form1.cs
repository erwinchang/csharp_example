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
            radioButton1.Text = "男性";
            radioButton1.Appearance = Appearance.Normal;
            radioButton1.CheckAlign = ContentAlignment.TopRight;
            radioButton1.Checked = true;
        }
    }
}
