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
            string[] list = new string[] { "奇萊山", "大霸尖山", "玉山", "雪山" };
            CboList.Items.AddRange(list);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool exist = CboList.Items.Contains(CboList.Text);
            if (exist == false)
                CboList.Items.Add(CboList.Text);
            else
            {
                MessageBox.Show($"{CboList.Text} 在百岳清單中已經存在");
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            CboList.Items.RemoveAt(CboList.SelectedIndex);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            CboList.Items.Clear();
            CboList.Text = "";
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            CboList.Sorted = true;
            CboList.Sorted = false;
        }
    }
}
