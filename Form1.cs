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
            this.IsMdiContainer = true;   //建立多重表單
            openFileDialog1.Filter = "JPEG|*.jpg|BMP|*.bmp|GIF|*.gif|PNG|*.png";
        }

        private void MnuOpen_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine($"filename:{openFileDialog1.FileName}");
                try
                {
                    FrmPic FPic = new FrmPic();
                    FPic.MdiParent = this;  //多重文件介面(MDI)父表單
                    FPic.Text = openFileDialog1.FileName;
                    FPic.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                    FPic.Show();
                }
                catch
                {
                    MessageBox.Show("請選取適當格式的圖檔", "注意");
                }
            }
        }
    }
}
