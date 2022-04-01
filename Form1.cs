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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvokerCommand invokerCmd = new InvokerCommand(2);
            BusinessCheckCommand bcc = new BusinessCheckCommand();
            IdentityChecksCommand identityChecks = new IdentityChecksCommand(bcc);
            DoCheckCommand doCheck = new DoCheckCommand(bcc);

            invokerCmd.setCommand(0, identityChecks);
            invokerCmd.setCommand(1, doCheck);

            invokerCmd.runAllCommands();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InvokerCommand invokerCmd = new InvokerCommand(1);
            BusinessCheckCommand bcc = new BusinessCheckCommand();

            IdentityChecksCommand identityChecks = new IdentityChecksCommand(bcc);
            invokerCmd.setCommand(0, identityChecks);

            invokerCmd.runCommand(0);
        }
    }
}
