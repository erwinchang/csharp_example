using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram
    {
    }

    //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/sealed
    public sealed class SingletonServiceManager
    {
        private static SingletonServiceManager manager;
        private static object syncRoot = new Object();

        static SingletonServiceManager()
        {
            Console.WriteLine("1. exe static constructor");
        }

        SingletonServiceManager()
        {
            Console.WriteLine("2. exe constructor");
        }

        public static SingletonServiceManager Instance
        {
            get {
                lock (syncRoot)
                {
                    if(manager == null)
                    {
                        manager = new SingletonServiceManager();
                    }
                    return manager;
                }
            }
        }

        public void Run()
        {
            Console.WriteLine("Service Run...");
        }
        public void Exit()
        {
            Console.WriteLine("Service Exit...");
        }
    }
}
