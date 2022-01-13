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
        string[] scene = new string[] {"陽明山","慈湖","獅頭山","梨山","日月潭",
                                        "阿里山","太平山","小硫球"};
        string[] city = new string[] {"台北","桃園","苗栗","台中","南投","嘉義",
                                    "宜蘭","屏東"};
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LstPlace.Items.AddRange(scene);
            LstPlace.SetSelected(0, true);
        }

        private void LstPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtCity.Text = "";
            for (int i = 0; i < LstPlace.Items.Count; i++)
            {

                if (LstPlace.GetSelected(i))
                    TxtCity.Text += $"景點: {LstPlace.Items[i]}\t 縣市: {city[i]}\r\n";
            }
        }
    }
}
