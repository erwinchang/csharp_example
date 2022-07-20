using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://dotblogs.com.tw/yc421206/2011/01/04/20574
    public class MyExample
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("ThreadProc: {0}, {1}", i, Thread.CurrentThread.ThreadState);
                Thread.Sleep(1000);
            }
        }
        public void Test()
        {
            Debug.WriteLine("Main thread: Start a second thread.");
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.IsBackground = true;
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine("Main thread: Do some work");
                Thread.Sleep(1);
            }
            Debug.WriteLine("Press Enter to end program.");
            Console.ReadLine();
            Debug.WriteLine("Exit");
        }
    }
}
