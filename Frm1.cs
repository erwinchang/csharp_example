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
    public partial class Frm1 : Form
    {
        public Frm1()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Txt1.Text) || string.IsNullOrEmpty(Txt2.Text) || string.IsNullOrEmpty(Txt3.Text))
            {
                MessageBox.Show("資料填寫不完整");
            }
            else
            {
                PubClass.sMsg = PubClass.NewLine("姓名 :" + Txt1.Text);
                PubClass.sMsg += PubClass.NewLine("電話 :" + Txt2.Text);
                PubClass.sMsg += PubClass.NewLine("電子信箱 :" + Txt3.Text);
                Console.WriteLine("sMsg:" + PubClass.sMsg);
                Close();
                Frm2 f2 = new Frm2();
                f2.Show();
            }
        }
    }
}
