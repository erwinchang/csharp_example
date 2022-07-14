using Faker;
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
        BindingList<Part> listOfParts;
        public Form1()
        {
            InitializeComponent();
            listOfParts = new BindingList<Part>();

            listOfParts.Add(new Part("Widget", 1234));
            listOfParts.Add(new Part("Gadget", 5647));
            listBox1.DataSource = listOfParts;
            listBox1.DisplayMember = "PartName";
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            listOfParts.Add(new Part("T11", 5647));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listOfParts.Clear();
        }
    }

    //https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.bindinglist-1?redirectedfrom=MSDN&view=net-6.0
    // A simple business object for example purposes.
    public class Part
    {
        private string name;
        private int number;
        public Part() { }
        public Part(string nameForPart, int numberForPart)
        {
            PartName = nameForPart;
            PartNumber = numberForPart;
        }
        public string PartName
        {
            get { return name; }
            set { name = value; }
        }
        public int PartNumber
        {
            get { return number; }
            set { number = value; }
        }
    }
}
