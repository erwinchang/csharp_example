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
                    string order = "";
                    int qty = 0, total = 0;
                    LblTotal.Text = order;

                    if(ChkM1.Checked == true)
                    {
                        try 
                        { qty = int.Parse(TxtM1.Text); }
                        catch
                        { LblMsg.Text = "請輸入正整數 !"; qty = 0; return; }

                        total += qty * 20;
                        order += $"蛋餅: {qty}份 {qty * 20} 元\n";
                    }
                    if(ChkM2.Checked == true)
                    {
                        try
                        { qty = int.Parse(TxtM2.Text); }
                        catch
                        { LblMsg.Text = "請輸入正整數 !"; qty = 0; return; }

                        total += qty * 30;
                        order += $"三明治: {qty}份 {qty * 30} 元\n";
                    }
                    if(ChkR1.Checked == true)
                    {
                        try
                        { qty = int.Parse(TxtR1.Text); }
                        catch
                        { LblMsg.Text = "請輸入正整數 !"; qty = 0; return; }

                        total += qty * 15;
                        order += $"豆漿: {qty}份 {qty * 15} 元\n";
                    }
                    if (ChkR2.Checked == true)
                    {
                        try
                        { qty = int.Parse(TxtR2.Text); }
                        catch
                        { LblMsg.Text = "請輸入正整數 !"; qty = 0; return; }

                        total += qty * 20;
                        order += $"奶茶: {qty}份 {qty * 20} 元\n";
                    }
                    LblTotal.Text = $"點餐清單: \n {order}\n 總價: {total} 元";
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
