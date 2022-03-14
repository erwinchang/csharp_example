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

        private void BtnSQL_Click(object sender, EventArgs e)
        {
            SourceStrategy ss = new SQLSource();
            ss.runFindString();
        }

        private void BtnHbase_Click(object sender, EventArgs e)
        {
            SourceStrategy ss = new HBaseSource();
            ss.runFindString();
        }

        private void BtnDynamic_Click(object sender, EventArgs e)
        {
            SourceStrategy ss = new HBaseSource();
            ss.setIFindString(new FindWithBigData());
            ss.runFindString();

            SourceStrategy sss = new HBaseSource("Cassandra");
            sss.runFindString();
        }
    }
}
