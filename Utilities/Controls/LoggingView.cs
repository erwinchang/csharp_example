using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Controls
{
    public partial class LoggingView : Component
    {
        public LoggingView()
        {
            InitializeComponent();
        }

        public LoggingView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
