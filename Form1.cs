using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int countDown = 3;
            LblMsg.Text = countDown.ToString() + "秒後啟動下載...";
            Application.DoEvents();

            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    countDown--;
                    LblMsg.Text = countDown.ToString() + "秒後啟動下載...";
                    Application.DoEvents();
                    if (countDown == 0)
                    {
                        button1_Click(button1, new EventArgs());
                        //button2_Click(button2, new EventArgs());
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                LblMsg.Text = ex.ToString();
            }
            LblMsg.Text = "欄位填寫未齊全 ...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button2_Click");
        }
    }
}
