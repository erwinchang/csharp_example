using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            //this.KeyDown += MainForm_KeyDown;
        }
        
        //private void MainForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Console.WriteLine(e.KeyValue);
        //}
    }
}
