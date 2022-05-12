using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WatchdogLib
{
    class Worker
    {
        private readonly TaskScheduler _callbackThread;

        //task採用跟UI一樣的thread(FromCurrentSynchronizationContext)才能更新UI
        //https://docs.microsoft.com/zh-tw/dotnet/api/system.threading.tasks.taskscheduler?view=netframework-4.7.2
        private static TaskScheduler CurrentTaskScheduler
        {
            get
            {
                return (SynchronizationContext.Current != null
                            ? TaskScheduler.FromCurrentSynchronizationContext()
                            : TaskScheduler.Default);
            }
        }

        public Worker() : this(CurrentTaskScheduler)
        {
            
        }

        public Worker(TaskScheduler callbackThread)
        {
            _callbackThread = callbackThread;
        }
    }
}
