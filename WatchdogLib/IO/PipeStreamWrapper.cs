using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib.IO
{
    /// <summary>
    /// Wraps a <see cref="PipeStream"/> object to read and write .NET CLR objects.
    /// </summary>
    /// <typeparam name="TReadWrite">Reference type to read from and write to the pipe</typeparam>
    public class PipeStreamWrapper<TReadWrite> : PipeStreamWrapper<TReadWrite, TReadWrite>
        where TReadWrite : class
    {

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

    }
}
