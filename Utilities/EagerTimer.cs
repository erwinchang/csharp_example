using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


//System.timer不會立即執行Handler
//EagerTimer會立即執行Handler
namespace Utilities
{
    public class EagerTimer : Timer
    {
        public EagerTimer() : base() {}
        public EagerTimer(double interval) : base(interval) { }

        private event ElapsedEventHandler ElapsedHandler;
        public new event ElapsedEventHandler Elapsed
        {
            add { ElapsedHandler += value; base.Elapsed += value; }
            remove { ElapsedHandler -= value; base.Elapsed -= value; }
        }

        //https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
        //new 修飾詞則會「隱藏」virtual可存取的基底類別方法
        public new void Start()
        {
            // If AutoStart is enabled, we need to invoke the timer event manually
            if (AutoStart)
            {
                var onElapsedHandler = ElapsedHandler;
                if (onElapsedHandler != null)
                    onElapsedHandler.BeginInvoke(this, null, AutoStartCallback, ElapsedHandler); // fire immediately
            }

            // Proceed as normal
            base.Start();
        }

        //https://docs.microsoft.com/zh-tw/dotnet/api/system.componentmodel.categoryattribute?view=net-6.0
        //https://www.cnblogs.com/springyangwc/archive/2011/10/10/2205733.html
        //設定AutoStart相關屬性
        [Category("Behavior")]
        [DefaultValue(true)]
        [TimersDescription("TimerAutoStart")]
        public bool AutoStart { get; set; }

        private void AutoStartCallback(IAsyncResult result)
        {
            try
            {
                var handler = result.AsyncState as ElapsedEventHandler;
                if (handler != null) handler.EndInvoke(result);
            }
            catch { }
        }
    }
}
