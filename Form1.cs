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
            timer1.Start();
        }

        private delegate void InvokeCallback(string msg);
        private void button1_Click(object sender, EventArgs e)
        {
            //m_comm_MessageEvent("TEST11");
            var thread = new Thread(Test);
            thread.Start();
        }
        private void m_comm_MessageEvent(String msg)
        {
            //https://www.796t.com/content/1549952496.html
            Console.WriteLine($"InvokeRequired:{textBox1.InvokeRequired}");
            if (textBox1.InvokeRequired)
            {
                InvokeCallback msgCallback = new InvokeCallback(m_comm_MessageEvent);
                textBox1.Invoke(msgCallback, new object[] { msg });
            }
            else            
            {
                //form1 thread InvokeRequired=0
                textBox1.Text = msg;
            }                
        }
        private void Test()
        {
            m_comm_MessageEvent("TEST22");
        }

        private int cnt = 0;
        private void timer1_Tick(object sender, EventArgs e)
        { 
            m_comm_MessageEvent($"TEST :{cnt.ToString()}");
            cnt++;
        }
    }
}
