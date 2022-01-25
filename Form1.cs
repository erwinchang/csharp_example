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

        private void button1_Click(object sender, EventArgs e)
        {
            dt = new DataTable("new-table");
            dataGridView2.DataSource = dt;

            DataColumn dc;
            dc = new DataColumn("column0", typeof(String));
            dt.Columns.Add(dc);
            dc = new DataColumn("column1",typeof(DateTime));
            dt.Columns.Add(dc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt.Rows.Add("S00" + (++G_studentID), DateTime.Now);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(DataColumn col in dt.Columns)
            {
                Console.WriteLine(col.ToString());
            }
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine($"[{i++}] = {row[0].ToString()} , {row[1].ToString()}");
            }
            string name = dt.Rows[0][0].ToString();
            string time = dt.Rows[0]["column1"].ToString();
            Console.WriteLine("name" + name);
            Console.WriteLine("time" + time);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i= dt.Rows.Count-1; i>=0; i--)
            {
                dt.Rows.RemoveAt(i);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("0 count:" + dt.Rows.Count);
            dt.Rows[1].Delete();
            Console.WriteLine("1 count:" + dt.Rows.Count);
            dt.AcceptChanges();
            Console.WriteLine("2 count:" + dt.Rows.Count);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable table;
            table = MakeNameTable();
           
            DataRow row;
            row = table.NewRow();

            row["fName"] = "John";
            row["lName"] = "Smith";
            table.Rows.Add(row);

            foreach (DataColumn column in table.Columns)
                Console.WriteLine(column.ColumnName);

            dataGridView2.DataSource = table;
        }

        private DataTable MakeNameTable()
        {
            DataTable namesTable = new DataTable("Names");
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.Int32");
            idColumn.ColumnName = "id";
            idColumn.AutoIncrement = true;
            namesTable.Columns.Add(idColumn);

            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = System.Type.GetType("System.String");
            fNameColumn.ColumnName = "Fname";
            fNameColumn.DefaultValue = "Fname";
            namesTable.Columns.Add(fNameColumn);

            DataColumn lNameColumn = new DataColumn();
            lNameColumn.DataType = System.Type.GetType("System.String");
            lNameColumn.ColumnName = "LName";
            namesTable.Columns.Add(lNameColumn);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = idColumn;
            namesTable.PrimaryKey = keys;
            return namesTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable table;
            table = MakeTable();

            DataRow row;
            row = table.NewRow();

            Console.WriteLine("New Row", row.RowState);

            table.Rows.Add(row);
            Console.WriteLine("AddRow " + row.RowState);
            table.AcceptChanges();
            // Unchanged row.
            Console.WriteLine("AcceptChanges " + row.RowState);
            row["FirstName"] = "Scott";
            // Modified row.
            Console.WriteLine("Modified " + row.RowState);
            row.Delete();
            // Deleted row.
            Console.WriteLine("Deleted " + row.RowState);

        }
        private DataTable MakeTable()
        {
            DataTable table = new DataTable("table");
            DataColumn fnameColumn = new DataColumn(
                "FirstName", Type.GetType("System.String"));
            table.Columns.Add(fnameColumn);
            return table;
        }
    }
}
