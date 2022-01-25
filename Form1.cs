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
            DataTable dt = new DataTable("Student");
            dt.Columns.Add("StudentID", typeof(String));
            dt.Columns.Add("StudentName", typeof(String));
            dt.Columns.Add("Math", typeof(Double));
            dt.Columns.Add("Eng", typeof(Double));

            dt.Columns["StudentID"].MaxLength = 10;
            dt.Columns["StudentID"].AllowDBNull = false;
            dt.Columns["StudentID"].Unique = true;
            dt.Columns["StudentName"].MaxLength = 10;
            dt.Columns["StudentName"].AllowDBNull = false;

            dataGridView1.DataSource = dt;
        }
    }
}
