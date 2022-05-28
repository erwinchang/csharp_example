﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace WatchdogClient.Threading
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

        public event WorkerSucceededEventHandler Succeeded;
        public event WorkerExceptionEventHandler Error;

        public Worker() : this(CurrentTaskScheduler)
        {
        }

        public Worker(TaskScheduler callbackThread)
        {
            _callbackThread = callbackThread;
        }

        public void DoWork(Action action)
        {
            new Task(DoWorkImpl, action, CancellationToken.None, TaskCreationOptions.LongRunning).Start();
        }

        private void DoWorkImpl(object oAction)
        {
            var action = (Action)oAction;
            try
            {
                action();
                Callback(Succeed);
            }
            catch (Exception e)
            {
                Callback(() => Fail(e));
            }
        }

        private void Succeed()
        {
            if (Succeeded != null)
                Succeeded();
        }

        private void Fail(Exception exception)
        {
            if (Error != null)
                Error(exception);
        }

        private void Callback(Action action)
        {
            Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, _callbackThread);
        }
    }

    internal delegate void WorkerSucceededEventHandler();
    internal delegate void WorkerExceptionEventHandler(Exception exception);
}
