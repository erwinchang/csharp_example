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
        private List<TestPlanTask> testTask = new List<TestPlanTask>();
        private DataGridView dataGridView1 = new DataGridView();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Controls.Add(dataGridView1);

            Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            testTask.Add(new TestPlanTask(1, "XTT1-FILE-NAME",25.0,3.1));
            testTask.Add(new TestPlanTask(2, "XTT2-FILE-NAME", 25.0, 3.2));
            testTask.Add(new TestPlanTask(3, "XTT3-FILE-NAME", 25.0, 3.3));
            testTask.Add(new TestPlanTask(4, "XTT4-FILE-NAME----------", 25.0, 3.4));

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = testTask;
            AddColumns();
        }

        private void AddColumns()
        {
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "CaseID";
            idColumn.DataPropertyName = "Id";
            idColumn.ReadOnly = true;

            DataGridViewTextBoxColumn xttFileNameColumn = new DataGridViewTextBoxColumn();
            xttFileNameColumn.Name = "XTT File Name";
            xttFileNameColumn.DataPropertyName = "XTTFileName";
            xttFileNameColumn.ReadOnly = true;

            DataGridViewTextBoxColumn temperatureValueColumn = new DataGridViewTextBoxColumn();
            temperatureValueColumn.Name = "Temperature";
            temperatureValueColumn.DataPropertyName = "TemperatureValue";

            DataGridViewTextBoxColumn voltageValueColumn = new DataGridViewTextBoxColumn();
            voltageValueColumn.Name = "Voltage";
            voltageValueColumn.DataPropertyName = "VoltageValue";

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(xttFileNameColumn);
            dataGridView1.Columns.Add(temperatureValueColumn);
            dataGridView1.Columns.Add(voltageValueColumn);
        }
    }

}

public class TestPlanTask
{
    public int Id { get; set; }
    public String XTTFileName { get; set; }
    public double TemperatureValue { get; set; }
    public double VoltageValue { get; set; }

    public TestPlanTask(int id, String xttFileName, double temperature,double voltage)
    {
        Id = id;
        XTTFileName = xttFileName;
        TemperatureValue = temperature;
        VoltageValue = voltage;
    }
}