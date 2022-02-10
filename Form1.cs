using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        private static NLog.Logger Logger = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //https://nlog-project.org/documentation/v2.0.1/html/T_NLog_Targets_RichTextBoxTarget.htm
            NLog.Windows.Forms.RichTextBoxTarget target = new NLog.Windows.Forms.RichTextBoxTarget();
            target.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";
            target.ControlName = "richTextBox1";
            target.FormName = "Form1";
            target.UseDefaultRowColoringRules = true;
            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, NLog.LogLevel.Trace);

            Logger = NLog.LogManager.GetCurrentClassLogger();
            Logger.Fatal("Hello {0}", "Fatal");
            Logger.Error("Hello {0}", "Error");
            Logger.Warn("Hello {0}", "Warn");
            Logger.Info("Hello {0}", "Info");
            Logger.Debug("Hello {0}", "Debug");
            Logger.Trace("Hello {0}", "Trace");
        }
    }
}
