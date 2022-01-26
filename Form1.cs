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
            TxtW.Multiline = true;
            TxtW.Dock = DockStyle.Fill;
            MnuStyle1.CheckOnClick = true;
            MnuStyle2.CheckOnClick = true;
            MnuSet2.CheckOnClick = true;
            MnuSet1_Click(sender, e);
            TxtW.ContextMenuStrip = contextMenuStrip1;
            Clipboard.Clear();
        }

        private void MnuStyle_Click(object sender, EventArgs e)
        {

        }

        private void MnuSet1_Click(object sender, EventArgs e)
        {
            TxtW.Text = "做該做的事是智慧,\r\n 做不該做的事是愚痴";
            MnuStyle1.Checked = false;
            MnuStyle2.Checked = false;
            MnuSize1.Enabled = true;
            MnuSize2.Enabled = true;
            MnuSize3.Enabled = true;
            MnuSize4.Enabled = true;

            TxtW.Font = new Font("新細明體", 12, FontStyle.Regular);
        }

        private void MnuSet2_Click(object sender, EventArgs e)
        {
            if(MnuSet2.Checked == true)
            {
                MnuSize1.Enabled = false;
                MnuSize2.Enabled = false;
            }
            else
            {
                MnuSize3.Enabled = true;
                MnuSize4.Enabled = true;
            }
        }

        private void MnuSet3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MnuFont1_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font("新細明體", TxtW.Font.Size, TxtW.Font.Style);
        }

        private void MnuFont2_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font("標楷體", TxtW.Font.Size, TxtW.Font.Style);
        }

        private void MnuSize1_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font(TxtW.Font.Name, 9, TxtW.Font.Style);
        }

        private void MnuSize2_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font(TxtW.Font.Name, 12, TxtW.Font.Style);
        }

        private void MnuSize3_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font(TxtW.Font.Name, 20, TxtW.Font.Style);
        }

        private void MnuSize4_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font(TxtW.Font.Name, 24, TxtW.Font.Style);
        }

        private void MnuStyle1_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font(TxtW.Font.Name, TxtW.Font.Size, TxtW.Font.Style ^ FontStyle.Bold);
        }

        private void MnuStyle2_Click(object sender, EventArgs e)
        {
            TxtW.Font = new Font(TxtW.Font.Name, TxtW.Font.Size, TxtW.Font.Style ^ FontStyle.Italic);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.ToString() == "編輯")
            {
                if(TxtW.SelectionLength > 0)
                {
                    MnuEdit1.Enabled = true; //複製
                    MnuEdit3.Enabled = true; //剪下
                }
                else
                {
                    MnuEdit1.Enabled = false; //複製
                    MnuEdit3.Enabled = false; //剪下                    
                }

                if(Clipboard.GetText() == "")
                {
                    MnuEdit2.Enabled = false;
                }
                else
                {
                    MnuEdit2.Enabled = true;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (TxtW.SelectionLength > 0)
            {
                CMnuEdit1.Enabled = true; //複製
                CMnuEdit3.Enabled = true; //剪下
            }
            else
            {
                CMnuEdit1.Enabled = false; //複製
                CMnuEdit3.Enabled = false; //剪下                    
            }

            if (Clipboard.GetText() == "")
            {
                CMnuEdit2.Enabled = false;
            }
            else
            {
                CMnuEdit2.Enabled = true;
            }
        }

        private void MnuEdit1_Click(object sender, EventArgs e)
        {
            TxtW.Copy();
        }

        private void MnuEdit2_Click(object sender, EventArgs e)
        {
            TxtW.Paste();
        }

        private void MnuEdit3_Click(object sender, EventArgs e)
        {
            TxtW.Cut();
        }

        private void CMnuEdit1_Click(object sender, EventArgs e)
        {
            TxtW.Copy();
        }

        private void CMnuEdit2_Click(object sender, EventArgs e)
        {
            TxtW.Paste();
        }

        private void CMnuEdit3_Click(object sender, EventArgs e)
        {
            TxtW.Cut();
        }
    }
}
