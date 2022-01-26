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
            McdDate.MinDate = DateTime.Today;
            McdDate.MaxSelectionCount = 7;
            McdDate.SelectionStart = DateTime.Today;
            //McdDate.ShowToday = false;
        }

        private void McdDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            double m = McdDate.SelectionStart.Month;
            switch (Math.Floor(m - 1) / 3)
            {
                case 0:
                    this.BackColor = Color.LightGreen;
                    break;
                case 1:
                    this.BackColor = Color.LightBlue;
                    break;
                case 2:
                    this.BackColor = Color.Orange;
                    break;
                case 3:
                    this.BackColor = Color.White;
                    break;
            }
        }

        private void McdDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime dstart = McdDate.SelectionStart;
            DateTime dend = McdDate.SelectionEnd;
            TimeSpan ts = dend - dstart;
            int days = ts.Days + 1;
            int rent;
            switch(days)
            {
                case 1:
                    rent = 2500;
                    break;
                case 2:
                case 3:
                    rent = 2300;
                    break;
                default:
                    rent = 2000;
                    break;
            }
            LblMoney.Text = $"{days} 天的租金為 {days * rent} 元";
        }
    }
}
