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
            this.objectListView1.SetObjects(haha.GET());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            haha newObject = new haha("memo", "zezo");
            objectListView1.AddObject(newObject);
        }
    }
}
