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
            Process p = new Process();
            Console.WriteLine("Current State = " + p.CurrentState);
            Console.WriteLine("Command.Begin: Current State = " + p.MoveNext(Command.Begin));
            Console.WriteLine("Command.Pause: Current State = " + p.MoveNext(Command.Pause));
            Console.WriteLine("Command.End: Current State = " + p.MoveNext(Command.End));
            Console.WriteLine("Command.Exit: Current State = " + p.MoveNext(Command.Exit));
        }
    }
}
