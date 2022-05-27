using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib
{
    public class ApplicationHandler
    {
        public List<ProcessHandler> ProcessHandlers { get; set; }
        public int NonResponsiveInterval { get; set; }
        public string ApplicationPath { get; set; }
        public string ApplicationName { get; set; }
        public Logger Logger { get; set; }

        public bool Active { get; set; }
        public uint StartupMonitorDelay { get; set; }

        public void Check()
        {
            if (!Active) return;
            // Check if  new unmonitored process is running 
            //HandleDuplicateProcesses();
            //HandleNonResponsiveProcesses();
            HandleProcessNotRunning();
        }

        //移除相同名稱的process
        public void HandleDuplicateProcesses()
        {
            //Loop through the running processes in with the same name 
        }

        private void HandleNonResponsiveProcesses()
        {

        }

        private void HandleProcessNotRunning()
        {
            var processes = Process.GetProcessesByName(ApplicationName);

            if(processes.Length == 0){
                // Start new process
                var processHandler = new ProcessHandler
                {
                    WaitForExit = false,
                    NonResponsiveInterval = NonResponsiveInterval,
                    StartingInterval = StartupMonitorDelay
                };
                Logger.Info("No process of application {0} is running, so one will be started", ApplicationName);
                processHandler.CallExecutable(ApplicationPath, "");
            }
        }
    }
}
