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
        private BindingSource customersBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
           // dataGridView1.Dock = DockStyle.Top;

            BindingList<DemoCustomer> customerList = new BindingList<DemoCustomer>();
            customerList.Add(DemoCustomer.CreateNewCustomer());
            customerList.Add(DemoCustomer.CreateNewCustomer());
            customerList.Add(DemoCustomer.CreateNewCustomer());

            customersBindingSource.DataSource = customerList;
            dataGridView1.DataSource = customersBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<DemoCustomer> customerList = customersBindingSource.DataSource as BindingList<DemoCustomer>;
            customerList[0].CustomerName = "Tailspin Toys";
            customerList[0].PhoneNumber = "(708)555-0150";
        }
    }
}
