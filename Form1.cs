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

        private void button1_Click(object sender, EventArgs e)
        {
            var accounts = new List<Account> {
            new Account {
                          ID = 345678,
                        Balance = 541.27
                        },
            new Account {
                          ID = 1230221,
                        Balance = -127.44
                    }
            };
            MyProgram.DisplayInExcel(accounts);
        }
    }
}
