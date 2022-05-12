﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public class AsyncWorker
    {
        public enum State
        {
            Stopped,
            Running,
            Suspended
        }

        /// <summary>
        /// Main worker method to do some work.
        /// </summary>
        /// <returns>true is there is more work to do, otherwise false and worker will wait until signaled with SignalWorker().</returns>
        public delegate bool AsyncWorkerJob();

        private volatile State _state = State.Stopped;
        private volatile State _requestedState = State.Stopped;

        private readonly EventWaiter _eventWaiter = new EventWaiter();

        private readonly object _lock = new object();
        private readonly AsyncWorkerJob _workerJob;
        private System.Threading.Tasks.Task _workerTask;
        public string Name { get; set; }

        public AsyncWorker(AsyncWorkerJob workerJob)
        {
            if (workerJob == null) throw new ArgumentNullException("workerJob");
            _workerJob = workerJob;
        }

        public void Start()
        {
            lock (_lock)
            {
                if (_state == State.Stopped)
                {
                    _requestedState = _state = State.Running;
                    _eventWaiter.Reset();


                    // prefer using Task.Factory.StartNew for .net 4.0. For .net 4.5 Task.Run is the better option.
                    _workerTask = Task.Factory.StartNew(x =>
                    {
                        while (true)
                        {
                            if (_state == State.Stopped) break;

                            bool haveMoreWork = false;
                            if (_state == State.Running)
                            {
                                haveMoreWork = _workerJob();

                                // Check if state has been changed in workerJob thread.
                                if (_requestedState != _state && _requestedState == State.Stopped)
                                {
                                    _state = _requestedState;
                                    break;
                                }
                            }

                            if (!haveMoreWork || _state == State.Suspended) _eventWaiter.WaitOne(Timeout.Infinite);
                            _state = _requestedState;
                        }
                    }, CancellationToken.None, TaskCreationOptions.LongRunning);

                }
            }
        }
    }
}
