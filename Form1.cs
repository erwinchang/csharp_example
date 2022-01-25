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
        DataTable dt;
        int G_studentID = 0;
        Random rd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnDataRow1.Enabled = false;
            BtnNewRow.Enabled = false;
        }

        private void BtnNewRow_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = dt.NewRow();
            
            
            row["StudentID"] = "S00" + (++G_studentID);
            row["StudentName"] = G_studentID;
            row["Math"] = Double.Parse((rd.NextDouble() * 100.0).ToString("0.00"));
            row["Eng"] = Double.Parse((rd.NextDouble() * 100.0).ToString("0.00"));
            dt.Rows.Add(row);
        }

        private void BtnDataRow1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = dt.NewRow();
            dt.Rows.Add(new Object[] 
            { "S00" + (++G_studentID), 
                G_studentID, 
                Double.Parse((rd.NextDouble() * 100.0).ToString("0.00")), 
                Double.Parse((rd.NextDouble() * 100.0).ToString("0.00")) 
            });
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            dt = new DataTable("Student");
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

            BtnDataRow1.Enabled = true;
            BtnNewRow.Enabled = true;
        }
    }
}
