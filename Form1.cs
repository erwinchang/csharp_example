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
            //https://www.it145.com/9/77293.html
            //toolStripStatusLabel3.Text = "登入時間：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            toolStripStatusLabel3.Text = "登入時間：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            toolStripStatusLabel2.Text = "---------------";
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "您好,歡迎登入系統！" + "當前時間：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Spring = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Spring = false;
        }
    }
}
