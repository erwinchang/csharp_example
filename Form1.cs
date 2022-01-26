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

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PicPicture.Left = 5;
            PicPicture.Top = 0;
            TsCboPic.SelectedIndex = 0;
            TsTxtMsg.Text = "Test11";
            label1.Text = TsTxtMsg.Text;
            label1.Parent = PicPicture;  //lable會跟著picture移重, lable要放在picture裡面
            label1.BackColor = Color.Transparent;
        }

        private void TsBtnStart_Click(object sender, EventArgs e)
        {
            TmrMove.Enabled = true;
        }

        private void TsBtnStop_Click(object sender, EventArgs e)
        {
            TmrMove.Enabled = false;
        }

        private void TmrMove_Tick(object sender, EventArgs e)
        {
            PicPicture.Left -= 5;
            if (PicPicture.Left < -200)
                PicPicture.Left = 200;
        }

        private void TsCboPic_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"idx:{TsCboPic.SelectedIndex}");
            switch (TsCboPic.SelectedIndex)
            {
                case 0:
                    PicPicture.Image = Properties.Resources.pic;
                    break;
                case 1:
                    PicPicture.Image = Properties.Resources.pic2;
                    break;
                case 2:
                    PicPicture.Image = Properties.Resources.pic3;
                    break;
            }
        }

        private void TsTxtMsg_TextChanged(object sender, EventArgs e)
        {
            label1.Text = TsTxtMsg.Text;
        }

        private void TsTxtMsg_Click(object sender, EventArgs e)
        {

        }
    }
}
