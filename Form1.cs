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

        private void RdbUSD_CheckedChanged(object sender, EventArgs e)
        {
            if(RdbUSD.Checked == true)
            {
                double usd, twd;
                try
                {
                    twd = double.Parse(TxtInput.Text);                  
                }
                catch
                {
                    LblOutput.Text = "請輸入金額值 !";
                    return;
                }
                usd = Math.Round(twd / 28.32, 2);
                LblOutput.Text = $"美金  {usd} 元";
            }
        }

        private void RdbJPY_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbJPY.Checked == true)
            {
                double jpy, twd;
                try
                {
                    twd = double.Parse(TxtInput.Text);
                }
                catch
                {
                    LblOutput.Text = "請輸入金額值 !";
                    return;
                }

                jpy = Math.Round(twd / 0.2679, 2);
                LblOutput.Text = $"日幣 {jpy} 元";
            }
        }
    }
}
