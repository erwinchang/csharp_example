using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharp_example
{
    public class ExampleMain : ApplicationContext
    {
        private bool _disposed;
        private MainForm _mainForm;

        public ExampleMain()
        {
            _mainForm = new MainForm() { Visible = true };
            MainApplication();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // free other managed objects that implement


                // release any unmanaged objects
                // set object references to null
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        private void MainApplication()
        {
            new MainFormVM(_mainForm);
        }
    }
}
