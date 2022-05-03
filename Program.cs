using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //https://vimsky.com/zh-tw/examples/detail/csharp-property-system.appdomain.friendlyname.html
            Console.WriteLine("currentDomain.FriendlyName : {0}", AppDomain.CurrentDomain.FriendlyName);

            //https://docs.microsoft.com/zh-tw/dotnet/api/system.appdomain.friendlyname?view=net-6.0
            AppDomain root = AppDomain.CurrentDomain;
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = root.SetupInformation.ApplicationBase + @"MyAppSubfolder\";

            AppDomain domain = AppDomain.CreateDomain("MyDomain", null, setup);
            Console.WriteLine("Application base of {0}:\r\n\t{1}", root.FriendlyName, root.SetupInformation.ApplicationBase);
            Console.WriteLine("Application base of {0}:\r\n\t{1}", domain.FriendlyName, domain.SetupInformation.ApplicationBase);
            Console.WriteLine("");

            // Output to the console.
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("New domain: " + domain.FriendlyName);
            Console.WriteLine("Application base is: " + domain.BaseDirectory);
            Console.WriteLine("Relative search path is: " + domain.RelativeSearchPath);
            Console.WriteLine("Shadow copy files is set to: " + domain.ShadowCopyFiles);
            AppDomain.Unload(domain);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
