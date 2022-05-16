using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogClient.IO
{
    /// <summary>
    /// Wraps a <see cref="PipeStream"/> object to read and write .NET CLR objects.
    /// </summary>
    /// <typeparam name="TReadWrite">Reference type to read from and write to the pipe</typeparam>
    public class PipeStreamWrapper<TReadWrite> : PipeStreamWrapper<TReadWrite, TReadWrite>
        where TReadWrite : class
    {
        /// <summary>
        /// Constructs a new <c>PipeStreamWrapper</c> object that reads from and writes to the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">Stream to read from and write to</param>
        public PipeStreamWrapper(PipeStream stream) : base(stream)
        {
        }
    }

    /// <summary>
    /// Wraps a <see cref="PipeStream"/> object to read and write .NET CLR objects.
    /// </summary>
    /// <typeparam name="TRead">Reference type to read from the pipe</typeparam>
    /// <typeparam name="TWrite">Reference type to write to the pipe</typeparam>
    public class PipeStreamWrapper<TRead, TWrite>
        where TRead : class
        where TWrite : class
    {
        /// <summary>
        /// Gets the underlying <c>PipeStream</c> object.
        /// </summary>
        public PipeStream BaseStream { get; private set; }



        private readonly PipeStreamReader<TRead> _reader;
        private readonly PipeStreamWriter<TWrite> _writer;

        /// <summary>
        /// Constructs a new <c>PipeStreamWrapper</c> object that reads from and writes to the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">Stream to read from and write to</param>
        public PipeStreamWrapper(PipeStream stream)
        {
            BaseStream = stream;
            _reader = new PipeStreamReader<TRead>(BaseStream);
            _writer = new PipeStreamWriter<TWrite>(BaseStream);
        }
    }
}
