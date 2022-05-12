using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    // Functionality comparable to AutoResetEvent (http://www.albahari.com/threading/part2.aspx#_AutoResetEvent)
    // but implemented using the monitor class: not inter processs, but ought to be more efficient.
    public class EventWaiter
    {
        public enum WaitState
        {
            TimeOut,
            Normal
        }

        private readonly object _key = new object();
        private bool _block;

        /// <summary>
        /// start blocked (waiting for signal)
        /// </summary>
        public EventWaiter()
        {
            lock (_key)
            {
                _block = true;
                Monitor.Pulse(_key);
            }
        }

        /// <summary>
        /// Resets signal, will block threads entering Wait function
        /// </summary>
        public void Reset()
        {
            lock (_key)
            {
                _block = true;
            }
        }
    }
}
