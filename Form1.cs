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
        private Handler exHandler;
        int cnt;
        public Form1()
        {
            InitializeComponent();
            exHandler = new Handler();
            cnt = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            exHandler.collection.Add($"Test-{cnt}");
            cnt++;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            exHandler.collection.Clear();
        }
    }
}
