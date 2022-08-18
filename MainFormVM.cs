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
            //https://stackoverflow.com/questions/3334927/windows-form-not-fire-keydown-event
            _mainForm.KeyPreview = true;
            _mainForm.KeyDown += MainFormVM_KeyDown;
        }
        
        private void MainFormVM_KeyDown(object sender, KeyEventArgs e)
        {
            //https://stackoverflow.com/questions/2146970/handle-the-keydown-event-when-altkey-is-pressed
            //https://stackoverflow.com/questions/164903/windows-forms-enter-keypress-activates-submit-button
            if (e.Alt && e.Control && (e.KeyCode == Keys.Enter))
            {
                Console.WriteLine("TEST");

                //https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.keyeventargs.handled?view=windowsdesktop-6.0
                e.Handled = true;
            }
        }
    }
}
