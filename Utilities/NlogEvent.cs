using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;
using NLog.Targets;

namespace Utilities
{
    class NlogEventTarget : TargetWithLayout
    {
        //https://nlog-project.org/documentation/v4.0.0/html/T_NLog_Targets_TargetWithLayout.htm
        //Write(LogEventInfo)	Writes logging event to the log target.classes.
        protected override void Write(LogEventInfo logEvent)
        {

        }
    }
}
