using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private readonly object _lock = new object();
        private readonly AsyncWorkerJob _workerJob;
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
                }
            }
        }
    }
}
