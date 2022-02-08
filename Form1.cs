using Newtonsoft.Json;
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
    class Mascot
    {
        public String name { get; set; }
        public String team { get; set; }
        public String catchPhrase { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Mascot nugetMascot = new Mascot()
            {
                name = "NuGet Warrior",
                team = "NuGet",
                catchPhrase = "Where packages come to life!"
            };
            string json = JsonConvert.SerializeObject(nugetMascot);
            Console.WriteLine($"json:{json}");
        }
    }
}
