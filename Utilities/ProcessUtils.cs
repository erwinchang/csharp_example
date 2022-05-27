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
    }
}
