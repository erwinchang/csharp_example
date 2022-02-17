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
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Controls.Add(dataGridView1);
        }
    }
}

public class TestPlanTask
{
    public int Id;
    public String XTTFileName;
    public double TemperatureValue;
    public double VoltageValue;

    public TestPlanTask(int id, String xttFileName, double temperature,double voltage)
    {
        Id = id;
        XTTFileName = xttFileName;
        TemperatureValue = temperature;
        VoltageValue = voltage;
    }
}