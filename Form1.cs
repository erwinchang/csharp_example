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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://www.c-sharpcorner.com/uploadfile/mahesh/tablelayoutpanel-in-C-Sharp/
            tableLayoutPanel1.Visible = false;

            TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();
            dynamicTableLayoutPanel.Dock = DockStyle.Top;

            dynamicTableLayoutPanel.Location = new Point(26, 12);
            dynamicTableLayoutPanel.Name = "TableLayoutPanel1";
            dynamicTableLayoutPanel.Size = new Size(228, 200);
            dynamicTableLayoutPanel.BackColor = Color.LightBlue;
            // Add rows and columns  
            dynamicTableLayoutPanel.ColumnCount = 3;
            dynamicTableLayoutPanel.RowCount = 5;
            dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(10, 10);
            textBox1.Text = "I am a TextBox5";
            textBox1.Size = new Size(200, 30);
            CheckBox checkBox1 = new CheckBox();
            checkBox1.Location = new Point(10, 50);
            checkBox1.Text = "Check Me";
            checkBox1.Size = new Size(200, 30);
            // Add child controls to TableLayoutPanel and specify rows and column  
            dynamicTableLayoutPanel.Controls.Add(textBox1, 0, 0);
            dynamicTableLayoutPanel.Controls.Add(checkBox1, 0, 1);
            Controls.Add(dynamicTableLayoutPanel);
        }
    }
}
