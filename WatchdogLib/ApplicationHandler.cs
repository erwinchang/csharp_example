using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchdogLib
{
    public class ApplicationHandler
    {
        public List<ProcessHandler> ProcessHandlers { get; set; }
        public bool Active { get; set; }

        public void Check()
        {
            if (!Active) return;
            // Check if  new unmonitored process is running 
            HandleDuplicateProcesses();
            HandleNonResponsiveProcesses();
        }

        //移除相同名稱的process
        public void HandleDuplicateProcesses()
        {
            //Loop through the running processes in with the same name 
        }

        private void HandleNonResponsiveProcesses()
        {

        }
    }
}
