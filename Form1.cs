using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;

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
            Console.WriteLine(TimeSpan.FromMilliseconds(1299630020));
            Console.WriteLine(TimeSpan.FromMilliseconds(3603001));
            Console.WriteLine(TimeSpan.FromMilliseconds(8157019263));
            Console.WriteLine(TimeSpan.FromMilliseconds(1299630020).Humanize(3));
            Console.WriteLine(TimeSpan.FromMilliseconds(3603001).Humanize(3));
            Console.WriteLine(TimeSpan.FromMilliseconds(8157019263).Humanize(3));
        }
    }
}
