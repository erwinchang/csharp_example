using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
