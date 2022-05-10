using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;
using NLog.Config;
using NLog.Targets;

namespace Utilities
{
    [Target("NlogEvent")]
    class NlogEventTarget : TargetWithLayout
    {
        private static NlogEventTarget _instance;

        public static NlogEventTarget Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NlogEventTarget();
                }
                return _instance;
            }
        }

        public NlogEventTarget()
        {

        }
        //https://nlog-project.org/documentation/v4.0.0/html/T_NLog_Targets_TargetWithLayout.htm
        //Write(LogEventInfo)	Writes logging event to the log target.classes.
        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = this.Layout.Render(logEvent);
            String filepath = @"D:\nlog-nlogEvent.txt";
            String msg = $"logMessage:{logMessage} {Environment.NewLine}";
            System.IO.File.AppendAllText(filepath, msg);
        }
    }
}
