using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public class MouseUti
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref MouseUti.Win32Point pt);


        //取得listViewTestPlan相對坐標
        public static Point GetMousePosition(Visual relativeTo)
        {
            MouseUti.Win32Point pt = new MouseUti.Win32Point();
            MouseUti.GetCursorPos(ref pt);
            Point pt2 =  relativeTo.PointFromScreen(new Point((double)pt.X, (double)pt.Y));
            WriteLine(string.Format("[GetMousePosition] x:{0},{1}, {2}",pt.X,pt.Y,pt2.ToString()));
            return pt2;
        }

        private static void WriteLine(string Msg)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"), Msg);
        }

        private struct Win32Point
        {
            public int X;
            public int Y;
        }
    }
}
