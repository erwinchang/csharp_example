using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace csharp_example
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bankAccounts = new List<Account>
            {
                new Account
                {
                    ID = 345,
                    Balance = 541.27
                },
                new Account
                {
                    ID = 123,
                    Balance = -127.44
                }
            };

            MyProgram.DisplayInExcel(bankAccounts);
        }

    }
}
