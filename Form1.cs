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

            for (int i = 0; i < 10; i++)
            {
                DataRow row = dataTable.NewRow();
                row[0] = i;
                row[1] = "name" + i;
                dataTable.Rows.Add(row);
            }

            //但是目前這樣有點不好看，周圍有空白，希望可以全部填滿，那就使用下面這行
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
