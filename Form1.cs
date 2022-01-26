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
        string[] bname = {"三國演義","西遊記","唐詩三百首","楚辭",
                        "西廂記","水許傳","紅樓夢","牡丹亭" };

        string[] author = {"羅貫中","吳承恩","孫洙","劉向",
                        "王實甫","施耐庵","曹雪芹","湯顯祖" };

        string[] kind = {"章回小說","章回小說","詩選","詩歌",
                    "戲曲","章回小說","章回小說","戲曲" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //https://vimsky.com/zh-tw/examples/detail/csharp-property-system.windows.forms.listview.largeimagelist.html
            // Create two ImageList objects.
            ImageList imgL = new ImageList();
            ImageList imgS = new ImageList();
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\三國演義S.bmp"));
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\西遊記S.bmp"));
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\唐詩三百首S.bmp"));
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\楚辭S.bmp"));
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\西廂記S.bmp"));
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\紅樓夢S.bmp"));
            imgS.Images.Add(Bitmap.FromFile("D:\\tmp\\牡丹亭S.bmp"));

            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\三國演義L.bmp"));
            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\西遊記L.bmp"));
            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\唐詩三百首L.bmp"));
            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\楚辭L.bmp"));
            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\西廂記L.bmp"));
            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\紅樓夢L.bmp"));
            imgL.Images.Add(Bitmap.FromFile("D:\\tmp\\牡丹亭L.bmp"));

            LstvBooks.LargeImageList = imgL;
            LstvBooks.SmallImageList = imgS;
            LstvBooks.Activation = ItemActivation.TwoClick;
            LstvBooks.CheckBoxes = true;
            CboView.Items.Add("大圖示"); CboView.Items.Add("詳細資料");
            CboView.Items.Add("小圖示"); CboView.Items.Add("清單");
            CboView.Items.Add("大圖示加詳細資料");
            CboView.SelectedIndex = 0;
            LstvBooks.Columns.Add("書名", 100);
            LstvBooks.Columns.Add("作者", 60);
            LstvBooks.Columns.Add("類別", 60);

            //https://vimsky.com/zh-tw/examples/detail/csharp-method-system.windows.forms.listbox.beginupdate.html

            // Stop the ListBox from drawing while items are added.
            LstvBooks.BeginUpdate();
            for(int i =0; i<bname.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(bname[i]);
                lvi.SubItems.Add(author[i].ToString());
                lvi.SubItems.Add(kind[i]);
                LstvBooks.Items.Add(lvi);
                LstvBooks.Items[i].ImageIndex = i;
            }
            // End the update process and force a repaint of the ListBox.
            LstvBooks.EndUpdate();
            
        }

        private void CboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"SelectedIndex:{CboView.SelectedIndex}");
            switch (CboView.SelectedIndex)
            {             
                case 0:
                    LstvBooks.View = View.LargeIcon;
                    break;
                case 1:
                    LstvBooks.View = View.Details;
                    break;
                case 2:
                    LstvBooks.View = View.SmallIcon;
                    break;
                case 3:
                    LstvBooks.View = View.List;
                    break;
                case 4:
                    LstvBooks.View = View.Tile;
                    break;
            }
        }

        private void LstBorrow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LstvBooks_ItemActivate(object sender, EventArgs e)
        {
            bool exist = LstBorrow.Items.Contains(bname[LstvBooks.SelectedIndices[0]]);
            if(exist != true)
            {
                DialogResult dr = MessageBox.Show("確定要借閱嗎?",
                    bname[LstvBooks.SelectedIndices[0]], MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    LstBorrow.Items.Add(bname[LstvBooks.SelectedIndices[0]]);
                }
            }
        }
    }
}
