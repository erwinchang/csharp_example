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
        public Form1()
        {
            InitializeComponent();
        }
        private void Test()
        {
            textBox1.AppendText("Hello" + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread = new Thread(Test);
            thread.Start();
        }


    }
}
