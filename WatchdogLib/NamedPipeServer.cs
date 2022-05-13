using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchdogLib.IO;

namespace WatchdogLib
{
    /// <summary>
    /// Wraps a <see cref="NamedPipeServerStream"/> and provides multiple simultaneous client connection handling.
    /// </summary>
    /// <typeparam name="TReadWrite">Reference type to read from and write to the named pipe</typeparam>
    /// 

    //HeartbeatServer.cs => private readonly NamedPipeServer<string> _server = new NamedPipeServer<string>(PipeName);
    //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
    public class NamedPipeServer<TReadWrite> : Server<TReadWrite, TReadWrite> where TReadWrite : class
    {
        /// <summary>
        /// Constructs a new <c>NamedPipeServer</c> object that listens for client connections on the given <paramref name="pipeName"/>.
        /// </summary>
        /// <param name="pipeName">Name of the pipe to listen on</param>
        public NamedPipeServer(string pipeName)
            : base(pipeName, null)
        {
        }

        /// <summary>
        /// Constructs a new <c>NamedPipeServer</c> object that listens for client connections on the given <paramref name="pipeName"/>.
        /// </summary>
        /// <param name="pipeName">Name of the pipe to listen on</param>
        /// <param name="pipeSecurity"></param>
        public NamedPipeServer(string pipeName, PipeSecurity pipeSecurity)
            : base(pipeName, pipeSecurity)
        {
        }
    }

    /// <summary>
    /// Wraps a <see cref="NamedPipeServerStream"/> and provides multiple simultaneous client connection handling.
    /// </summary>
    /// <typeparam name="TRead">Reference type to read from the named pipe</typeparam>
    /// <typeparam name="TWrite">Reference type to write to the named pipe</typeparam>
    public class Server<TRead, TWrite>
        where TRead : class
        where TWrite : class
    {

        private readonly string _pipeName;
        private readonly PipeSecurity _pipeSecurity;


        private int _nextPipeId;
        private volatile bool _shouldKeepRunning;
        private volatile bool _isRunning;

        /// <summary>
        /// Invoked whenever an exception is thrown during a read or write operation.
        /// </summary>
        public event PipeExceptionEventHandler Error;

        /// <summary>
        /// Constructs a new <c>NamedPipeServer</c> object that listens for client connections on the given <paramref name="pipeName"/>.
        /// </summary>
        /// <param name="pipeName">Name of the pipe to listen on</param>
        /// <param name="pipeSecurity"></param>
        public Server(string pipeName, PipeSecurity pipeSecurity)
        {
            _pipeName = pipeName;
            _pipeSecurity = pipeSecurity;
        }

        /// <summary>
        /// Begins listening for client connections in a separate background thread.
        /// This method returns immediately.
        /// </summary>
        public void Start()
        {
            _shouldKeepRunning = true;
            var worker = new Worker();
            worker.Error += OnError;
            worker.DoWork(ListenSync);
        }

        /// <summary>
        ///     Invoked on the UI thread.
        /// </summary>
        /// <param name="exception"></param>
        private void OnError(Exception exception)
        {
            if (Error != null)
                Error(exception);
        }

        #region Private methods
        private void ListenSync()
        {
            _isRunning = true;
            while (_shouldKeepRunning)
            {
                WaitForConnection(_pipeName, _pipeSecurity);
            }
            _isRunning = false;
        }

        private void WaitForConnection(string pipeName, PipeSecurity pipeSecurity)
        {
            NamedPipeServerStream handshakePipe = null;
            NamedPipeServerStream dataPipe = null;
            NamedPipeConnection<TRead, TWrite> connection = null;

            var connectionPipeName = GetNextConnectionPipeName(pipeName);

            try
            {
                // Send the client the name of the data pipe to use
                handshakePipe = PipeServerFactory.CreateAndConnectPipe(pipeName, pipeSecurity);  //https://blog.csdn.net/kingfox/article/details/7237842
                                                                                                 //WaitForConnection() 會等待clinet連線才會往下
                var handshakeWrapper = new PipeStreamWrapper<string, string>(handshakePipe);
                handshakeWrapper.WriteObject(connectionPipeName);
                handshakeWrapper.WaitForPipeDrain();
                handshakeWrapper.Close();

                // Wait for the client to connect to the data pipe
                dataPipe = PipeServerFactory.CreatePipe(connectionPipeName, pipeSecurity);
                dataPipe.WaitForConnection();     //WaitForConnection() 會等待clinet連線才會往下

                // Add the client's connection to the list of connections

            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Named pipe is broken or disconnected: {0}", e);
            }
        }

        private string GetNextConnectionPipeName(string pipeName)
        {
            return string.Format("{0}_{1}", pipeName, ++_nextPipeId);
        }
        #endregion
    }

    static class PipeServerFactory
    {
        public static NamedPipeServerStream CreateAndConnectPipe(string pipeName, PipeSecurity pipeSecurity)
        {
            var pipe = CreatePipe(pipeName, pipeSecurity);
            pipe.WaitForConnection();
            return pipe;
        }
        public static NamedPipeServerStream CreatePipe(string pipeName, PipeSecurity pipeSecurity)
        {
            return new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous | PipeOptions.WriteThrough, 0, 0, pipeSecurity);
        }
    }
}
