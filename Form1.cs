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
            //https://www.ruyut.com/2021/12/c-winform-datagridview.html
            //dataGridView1.Dock = DockStyle.Fill;

            //要顯示資料很簡單，先把資料儲存在DataTable中，之後再讓DataGridView直接顯示DataTable的所有資料即可

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("name", typeof(string));
            dataGridView1.DataSource = dataTable;
        }
    }
}
