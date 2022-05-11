using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Utilities
{
    public class EagerTimer : Timer
    {
        public EagerTimer() : base() {}
        public EagerTimer(double interval) : base(interval) { }
    }
}
