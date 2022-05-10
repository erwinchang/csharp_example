using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using NLog.Config;
using NLog.Layouts;

//https://dotblogs.com.tw/supershowwei/2020/06/22/112737
//https://github.com/NLog/NLog/wiki/How-to-write-a-custom-async-target
namespace NLog.Targets
{
    [Target("MyFirst")]
    public class MyFirstTarget : AsyncTaskTarget
    {
        public MyFirstTarget()
        {
            this.IncludeEventProperties = true; // Include LogEvent Properties by default
            this.Host = "localhost";
        }

        [RequiredParameter]
        public Layout Host { get; set; }

        protected override Task WriteAsyncTask(LogEventInfo logEvent, CancellationToken token)
        {
            string logMessage = this.RenderLogEvent(this.Layout, logEvent);
            string hostName = this.RenderLogEvent(this.Host, logEvent);
            IDictionary<string, object> logProperties = this.GetAllProperties(logEvent);

            return SendTheMessageToRemoteHost(hostName, logMessage, logProperties);
            
            //https://nlog-project.org/2015/06/30/extending-nlog-is-easy.html
        }

        private async Task SendTheMessageToRemoteHost(string hostName, string message, IDictionary<string, object> properties)
        {
            String filepath = @"D:\nlog.txt";
            String msg = $"hostName:{hostName}, message:{message} {Environment.NewLine}";
            System.IO.File.AppendAllText(filepath, msg);

            int i = 0;
            foreach (var kvp in properties)
            {
                msg = $"[{i}] key:{kvp.Key} {Environment.NewLine}";
                System.IO.File.AppendAllText(filepath, msg);
                i++;
            }
        }
    }

    [Target("NlogEvent")]
    public sealed class NlogEventTarget : TargetWithLayout
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
        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = this.Layout.Render(logEvent);
            String filepath = @"D:\nlog-NlogEvent.txt";
            String msg = $"logMessage:{logMessage}";
            System.IO.File.AppendAllText(filepath, msg);
        }
    }
}
