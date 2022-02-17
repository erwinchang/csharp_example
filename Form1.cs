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
        private List<Task> tasks = new List<Task>();
        private DataGridView dataGridView1 = new DataGridView();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Dock = DockStyle.Fill;
            Controls.Add(dataGridView1);
            Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tasks.Add(new Task(1));
            tasks.Add(new Task(2));
            tasks.Add(new Task(3));

            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = tasks;
            AddColumns();
        }

        private void AddColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Task";
            idColumn.DataPropertyName = "Id";
            idColumn.ReadOnly = true;

            dataGridView1.Columns.Add(idColumn);
        }
    }
}

public class Task
{
    public Task(Int32 id)
    {
        Id = id;
    }

    //記得要定議get,set這樣子,DataGridView才會要到資料
    public int Id { get; set; }
}