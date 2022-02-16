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
        SimpleStateMachine ss = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ss = new SimpleStateMachine();
            Console.WriteLine($"SS:{ss.ToString()}");
        }

        private void BtnTurnOn_Click(object sender, EventArgs e)
        {
            ss.TurnOn();
            Console.WriteLine($"SS:{ss.ToString()}");
        }

        private void BtnTurnOff_Click(object sender, EventArgs e)
        {
            ss.TurnOff();
            Console.WriteLine($"SS:{ss.ToString()}");
        }
    }
}
