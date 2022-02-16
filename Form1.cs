using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSM;

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
            SimpleStateMachine fsm = new SimpleStateMachine();
            Console.WriteLine("## Current State = " + fsm.currentState);
            Console.WriteLine("## Command.Begin: Current State = " + fsm.MoveNext(PlayerState.Run));
            Console.WriteLine("## Invalid transition: " + fsm.CanReachNext(PlayerState.Idle));
            Console.WriteLine("##　Previous State = " + fsm.previusState);
        }
    }
}
