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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            progressBar1.Step = 1;
            LblMsg.Text = "輸入秒數後按<開始>鈕";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Maximum = int.Parse(TxtSec.Text);
                progressBar1.Value = 0;
                timer1.Enabled = true;
            }
            catch
            {
                LblMsg.Text = "請輸入正整數 !";
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            LblMsg.Text = progressBar1.Value + " 秒";

            if(progressBar1.Value == progressBar1.Maximum)
            {
                LblMsg.Text = "倒數時間到 !";
                timer1.Enabled = false;
            }
        }
    }
}
