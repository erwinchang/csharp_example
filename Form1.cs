﻿using System;
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
            DialogResult result;
            result = MessageBox.Show("心美，看什麼都漂亮!", "開朗",
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
