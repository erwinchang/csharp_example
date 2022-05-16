using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WatchdogClient
{
    /// <summary>
    /// Represents a connection between a named pipe client and server.
    /// </summary>
    /// <typeparam name="TRead">Reference type to read from the named pipe</typeparam>
    /// <typeparam name="TWrite">Reference type to write to the named pipe</typeparam>
    public class NamedPipeConnection<TRead, TWrite>
        where TRead : class
        where TWrite : class
    {

        private readonly AutoResetEvent _writeSignal = new AutoResetEvent(false);
        private readonly Queue<TWrite> _writeQueue = new Queue<TWrite>();

        
        /// <summary>
        /// Adds the specified <paramref name="message"/> to the write queue.
        /// The message will be written to the named pipe by the background thread
        /// at the next available opportunity.
        /// </summary>
        /// <param name="message"></param>
        public void PushMessage(TWrite message)
        {
            _writeQueue.Enqueue(message);
            _writeSignal.Set();
        }
    }

    /// <summary>
    /// Handles new connections.
    /// </summary>
    /// <param name="connection">The newly established connection</param>
    /// <typeparam name="TRead">Reference type</typeparam>
    /// <typeparam name="TWrite">Reference type</typeparam>
    public delegate void ConnectionEventHandler<TRead, TWrite>(NamedPipeConnection<TRead, TWrite> connection)
        where TRead : class
        where TWrite : class;

    /// <summary>
    /// Handles messages received from a named pipe.
    /// </summary>
    /// <typeparam name="TRead">Reference type</typeparam>
    /// <typeparam name="TWrite">Reference type</typeparam>
    /// <param name="connection">Connection that received the message</param>
    /// <param name="message">Message sent by the other end of the pipe</param>
    public delegate void ConnectionMessageEventHandler<TRead, TWrite>(NamedPipeConnection<TRead, TWrite> connection, TRead message)
        where TRead : class
        where TWrite : class;
}
