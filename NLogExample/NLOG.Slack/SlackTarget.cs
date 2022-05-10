using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using NLog.Config;
using NLog.Layouts;

//https://dotblogs.com.tw/supershowwei/2020/06/22/112737
//https://github.com/NLog/NLog/wiki/How-to-write-a-custom-async-target
namespace NLog.Targets
{
    public class LogEventArgs : EventArgs
    {
        public List<string> LogLines { get; private set; }
        public LogEventArgs(List<string> logLines)
        {
            LogLines = logLines;
        }
    }

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
        public EventHandler<LogEventArgs> OnLogEvent;
        private readonly ConcurrentQueue<string> _logQueue;

        private static NlogEventTarget _instance;

        public static NlogEventTarget Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NlogEventTarget();
                    Register(_instance);
                }
                return _instance;
            }
        }

        public NlogEventTarget()
        {
            _logQueue = new ConcurrentQueue<string>();
            var timer = new System.Timers.Timer(100);
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }
        public static void Register(NlogEventTarget nlogEventTarget)
        {
            nlogEventTarget.Name = "event";
            nlogEventTarget.Layout = "${longdate} ${uppercase:${level}} ${message}";

            var config = LogManager.Configuration;
            config.AddTarget("nlogEvent", nlogEventTarget);
            var rule = new LoggingRule("*", LogLevel.Trace, nlogEventTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
            LogManager.Configuration.Reload();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var logList = new List<string>();
            var localValue = "";
            while (_logQueue.TryDequeue(out localValue)) logList.Add(localValue);

            if (logList.Count <= 0) return;
            if (OnLogEvent == null) return;
            var args = new LogEventArgs(logList);

            OnLogEvent(this, args);
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
