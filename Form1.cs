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
            LblShow.TextAlign = ContentAlignment.MiddleCenter;
            LblShow.Text = "輸入密碼後，按Check";
            TxtPW.MaxLength = 8;
            TxtPW.PasswordChar = '*';
            TxtMoney.Enabled = false;
            BtnOK.Enabled = false;
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if(TxtPW.Text == "123456")
            {
                BtnOK.Enabled = true;
                TxtMoney.Enabled = true;
                TxtMoney.Focus();
                LblShow.Text = "輸入提領金額，按OK";
            }
            else
            {
                LblShow.Text = "密碼錯誤! 重新輸入";
                TxtPW.Clear();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LblShow.Text = $"提領金額是 {TxtMoney.Text} 元";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
