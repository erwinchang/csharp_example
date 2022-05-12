﻿using System;
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
        /// Wait function. Blocks until signal is set or time-out
        /// </summary>
        /// <param name="timeOut">time-out in ms</param>
        /// <returns></returns>
        public WaitState WaitOne(int timeOut)
        {
            lock (_key)
            {
                // Check if signal has already been raised before the wait function is entered                
                if (!_block)
                {
                    // If so, reset event for next time and exit wait loop
                    _block = true;
                    return WaitState.Normal;
                }

                // Wait under conditions
                bool noTimeOut = true;
                while (noTimeOut && _block)
                {
                    noTimeOut = Monitor.Wait(_key, timeOut);
                }

                // Block Wait for next entry
                _block = true;

                // Return whether the Wait function was quit because of an Set event or timeout
                return noTimeOut ? WaitState.Normal : WaitState.TimeOut;
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
