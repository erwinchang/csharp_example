using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ProcessUtils
    {
        private static string StripExtension(string processname, string[] extensions = null)
        {
            Console.WriteLine("StripExtension 0, processname:{processname}");
            if (extensions == null) extensions = new string[] { ".exe", ".com", ".dll", ".bat", ".cmd", ".bin" };
            processname = processname.ToLowerInvariant();
            processname = extensions.Aggregate(processname, (current, extension) => current.Replace(extension, ""));
            Console.WriteLine("StripExtension 1, processname:{processname}");
            return processname;
        }
        public static string GetProcessName(string processname)
        {
            return StripExtension(Path.GetFileName(StripParameters(processname)));
        }
        private static string StripParameters(string processname)
        {
            var execVars = processname.Split(new char[] { ' ' }, 2);
            Console.WriteLine($"StripParameters, processname:{processname}, execVars[0]:#{execVars[0]}#, execVars[0]trim:#{execVars[0].Trim()}#");
            return execVars[0].Trim();
        }
        public static bool ProcessRunning(string processname)
        {
            processname = GetProcessName(processname);
            return (Process.GetProcessesByName(processname).Length > 0);
        }

        public static bool KillProcess(Process process)
        {
            const int timeoutNice = 500;
            const int timeoutTotal = 1500;
            {
                // 1. Ask nicely
                try
                {
                    process.CloseMainWindow();
                    process.WaitForExit(timeoutNice);
                }
                catch(Exception)
                {

                }
                if (process.HasExited) return true;

                // 2. Force process to stop
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {

                }
            }
            // See if processes are still running
            return process.WaitForExit(timeoutTotal);
        }
    }
}
