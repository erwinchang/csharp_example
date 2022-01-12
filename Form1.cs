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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtR1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblMsg_Click(object sender, EventArgs e)
        {
            
        }

        private void TbcOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtID.Text == "Jerry" && TxtPW.Text == "168")
            {
                LblMsg.Text = "歡迎使用本系統";
                if(TbcOrder.SelectedIndex == 3 )
                {

                }
            }
            else
            {
                TbcOrder.SelectedTab = tabPage1;
                LblMsg.Text ="請先輸入正確的使用者和密碼 !";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblMsg.Text = "活力早餐店 點餐系統";
        }
    }
}
