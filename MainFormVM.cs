using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharp_example
{
    public class MainFormVM
    {
        private readonly MainForm _mainForm;

        public MainFormVM(MainForm mainForm)
        {
            _mainForm = mainForm;
            _mainForm.KeyDown += MainFormVM_KeyDown;
        }
        
        private void MainFormVM_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyValue);
        }
    }
}
