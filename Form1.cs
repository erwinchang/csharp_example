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
            toolTip1.SetToolTip(TxtN1, "請輸入1-100的整數 !");
            toolTip1.SetToolTip(TxtN2, "請輸入1-100的整數 !");
        }

        private void BtnLCM_Click(object sender, EventArgs e)
        {
            int n1, n2, max, min, remainder;

            try { n1 = int.Parse(TxtN1.Text); }
            catch
            {
                MessageBox.Show("第一格輸入整數值 !", "錯誤",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try{ n2 = int.Parse(TxtN2.Text); }
            catch
            {
                MessageBox.Show("第二格輸入整數值 !", "錯誤",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if(n1 < 1 || n1 > 100){
                MessageBox.Show("第一格請輸入1-100的整數 !", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if(n2 < 1 || n2 > 100){
                MessageBox.Show("第二格請輸入1-100的整數 !", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if(n2 > n1) { max = n2; min = n1;}
            else        { max = n1; min = n2;}
            do{
                remainder = max % min;
                Console.WriteLine($"max:{max},min:{min},remainder:{remainder}");
                if(remainder == 0 ) break;
                max = min;
                min = remainder;
            }while(true);
            LblLCM.Text = $"{n1} 和 {n2} 的最大公因數是 {min}";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtN1.Text = "";
            TxtN2.Text = "";
            LblLCM.Text = "";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
