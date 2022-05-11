using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public partial class EagerTimer : Component
    {
        public EagerTimer()
        {
            InitializeComponent();
        }

        public EagerTimer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
