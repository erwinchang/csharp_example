using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example.TestProcOutput
{
    //http://csharphelper.com/blog/2020/04/build-a-windows-process-tree-in-c/
    class ProcessInfo : IComparable<ProcessInfo>
    {
        public Process TheProcess;
        public ProcessInfo Parent;
        public List<ProcessInfo> Children = new List<ProcessInfo>();

        public ProcessInfo(Process the_process)
        {
            TheProcess = the_process;
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]",
                TheProcess.ProcessName, TheProcess.Id);
        }

        public int CompareTo(ProcessInfo other)
        {
            return TheProcess.ProcessName.CompareTo(
                other.TheProcess.ProcessName);
        }
    }

    class MyProgram
    {
        static Process myprocess=null;
        static int myprocess_id =0;
        static Dictionary<int, ProcessInfo> process_dict;

        //http://csharphelper.com/blog/2020/04/build-a-windows-process-tree-in-c/
        public static void CreateProcessDict()
        {
            process_dict = new Dictionary<int, ProcessInfo>();
            foreach (Process process in Process.GetProcesses())
            {
                process_dict.Add(process.Id, new ProcessInfo(process));
            }

            // Get the parent/child info.
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessId, ParentProcessId FROM Win32_Process");
            ManagementObjectCollection collection = searcher.Get();

            // Create the child lists.
            foreach (var item in collection)
            {
                // Find the parent and child in the dictionary.
                int child_id = Convert.ToInt32(item["ProcessId"]);
                int parent_id = Convert.ToInt32(item["ParentProcessId"]);

                ProcessInfo child_info = null;
                ProcessInfo parent_info = null;

                if (process_dict.ContainsKey(child_id))
                    child_info = process_dict[child_id];

                if (process_dict.ContainsKey(parent_id))
                    parent_info = process_dict[parent_id];

                //if (child_info == null)
                //    Console.WriteLine("Cannot find child " + child_id.ToString() + " for parent " + parent_id.ToString());

                //if (parent_info == null)
                //    Console.WriteLine("Cannot find parent " + parent_id.ToString() + " for child " + child_id.ToString());

                if ((child_info != null) && (parent_info != null))
                {
                    parent_info.Children.Add(child_info);
                    child_info.Parent = parent_info;
                }
            }
        }

        public static void main()
        {
            Console.WriteLine("Run ADB Command");
            ExecuteCommand();
        }

        public static void StopProc()
        {        
            CreateProcessDict();
            KillProcessByDict(myprocess_id);
        }
        public static void KillProcessByDict(int process_id)
        {
            ProcessInfo p_info = null;
            if (process_dict.ContainsKey(process_id))
            {
                p_info = process_dict[process_id];
                KillChildrenId(process_id);

                if(isRunning(process_id) == true)
                {
                    var process1 = Process.GetProcessById(process_id);
                    Console.WriteLine($"Kill ProcessName:{ process1.ProcessName}, MainWindowTitle:{process1.MainWindowTitle}, pid:{process1.Id},");
                    process1.Kill();
                }
            }
        }
        public static void KillChildrenId(int process_id)
        {
            ProcessInfo p_info = null;
            ProcessInfo c_info = null;
            if (process_dict.ContainsKey(process_id))
            {
                p_info = process_dict[process_id];
                if (p_info.Children.Count == 0)
                {
                    if(isRunning(process_id) == true)
                    {
                        //kill process
                        var process1 = Process.GetProcessById(process_id);
                        Console.WriteLine($"Kill ProcessName:{ process1.ProcessName}, MainWindowTitle:{process1.MainWindowTitle}, pid:{process1.Id},");
                        process1.Kill();
                    }
                }
                else
                {
                    for(int i=0; i< p_info.Children.Count; i++)
                    {
                        c_info = p_info.Children[i];
                        KillChildrenId(c_info.TheProcess.Id);
                    }
                    
                }
            }
        }

        //https://www.delftstack.com/howto/csharp/csharp-check-if-process-is-running/
        static bool isRunning(int id)
        {
            try
            {
                Process.GetProcessById(id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        //https://stackoverflow.com/questions/5519328/executing-batch-file-in-c-sharp
        public static void ExecuteCommand()
        {
            string command = @"D:\AutoThermal\Tools\ADB_r31.0.3\QCC5100_FTM_mode_open_5G.bat";
            int exitCode;
            ProcessStartInfo processInfo;
            
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            //processInfo.CreateNoWindow = true;    //false: 顯示console畫面
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            //processInfo.RedirectStandardError = true;   //false: 輸出導到console畫面
            //processInfo.RedirectStandardOutput = true;  //false: 輸出導到console畫面
            processInfo.WorkingDirectory = @"D:\AutoThermal\Tools\ADB_r31.0.3\";     //執行目錄位置
            myprocess = Process.Start(processInfo);

            Thread.Sleep(50);
            myprocess_id = myprocess.Id;
        }
    }
}
