using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NLog;

namespace WatchdogLib
{
    public class ApplicationHandler
    {
        private readonly HeartbeatServer _heartbeatServer;

        public List<ProcessHandler> ProcessHandlers { get; set; }
        public int NonResponsiveInterval { get; set; }
        public string ApplicationPath { get; set; }
        public string ApplicationName { get; set; }
        public bool UseHeartbeat { get; set; }
        public Logger Logger { get; set; }
        public bool GrantKillRequest { get; set; }
        public uint HeartbeatInterval { get; set; }
        public int MaxProcesses { get; set; }
        public int MinProcesses { get; set; }
        public bool Active { get; set; }
        public bool KeepExistingNoProcesses { get; set; }
        public uint StartupMonitorDelay { get; set; }


        public ApplicationHandler(ApplicationHandlerConfig applicationHandlerConfig)
        {
            Logger = LogManager.GetLogger("WatchdogServer");
            ProcessHandlers = new List<ProcessHandler>();
            Set(applicationHandlerConfig);
            _heartbeatServer = HeartbeatServer.Instance;
        }

        public void Set(ApplicationHandlerConfig applicationHandlerConfig)
        {
            ApplicationName = applicationHandlerConfig.ApplicationName;
            ApplicationPath = applicationHandlerConfig.ApplicationPath;
            NonResponsiveInterval = applicationHandlerConfig.NonResponsiveInterval;
            HeartbeatInterval = applicationHandlerConfig.HeartbeatInterval;
            MinProcesses = applicationHandlerConfig.MinProcesses;
            MaxProcesses = applicationHandlerConfig.MaxProcesses;
            KeepExistingNoProcesses = applicationHandlerConfig.KeepExistingNoProcesses;
            UseHeartbeat = applicationHandlerConfig.UseHeartbeat;
            GrantKillRequest = applicationHandlerConfig.GrantKillRequest;
            Active = applicationHandlerConfig.Active;
            StartupMonitorDelay = applicationHandlerConfig.StartupMonitorDelay;
            Active = applicationHandlerConfig.Active;
        }

        public void Check()
        {
            if (!Active) return;
            // Check if  new unmonitored process is running 
            //HandleDuplicateProcesses();
            HandleExitedProcesses();
            HandleNonResponsiveProcesses();
            HandleProcessNotRunning();
        }

        //移除相同名稱的process
        public void HandleDuplicateProcesses()
        {
            //Loop through the running processes in with the same name 
        }

        private void HandleNonResponsiveProcesses()
        {
            for (var index = 0; index < ProcessHandlers.Count; index++)
            {
                var processHandler = ProcessHandlers[index];
                if (processHandler.HasExited) continue; // We will deal with this later
                if (processHandler.IsStarting)
                {
                    //process _fromStart.ElapsedMilliseconds < StartingInterval
                    Debug.WriteLine("Process {0} is still in startup phase, no checking is being performed", processHandler.Name);
                    continue; // Is still starting up, so ignore
                }
                if (_heartbeatServer.HeartbeatTimedOut(processHandler.Name, HeartbeatInterval / 2) && UseHeartbeat)
                {
                    //todo: add throttling
                    Logger.Warn("No heartbeat received from process {0} within the soft limit", processHandler.Name);
                }

                var notRespondingAfterInterval = processHandler.NotRespondingAfterInterval;
                var noHeartbeat = _heartbeatServer.HeartbeatTimedOut(processHandler.Name, HeartbeatInterval) && UseHeartbeat;
                var requestedKill = _heartbeatServer.KillRequested(processHandler.Name);

                var performKill = notRespondingAfterInterval || noHeartbeat || requestedKill;
                var reason = notRespondingAfterInterval ? "not responding" : noHeartbeat ? "not sending a heartbeat signal within hard limit" : "requesting to be killed";

                if (performKill)
                {
                    Logger.Error("process {0} is {1}, and will be killed ", processHandler.Name, reason);
                    if (processHandler.Kill())
                    {
                        Logger.Error("Process {0} was {1} and has been successfully killed ", processHandler.Name, reason);

                        processHandler.Close();
                        var notEnoughProcesses = (ProcessNo(processHandler.Name) < MinProcesses);
                        var lessProcessesThanBefore = (ProcessNo(processHandler.Name) < MaxProcesses) && KeepExistingNoProcesses;

                        if (notEnoughProcesses || lessProcessesThanBefore)
                        {
                            processHandler.CallExecutable();
                        }
                        else
                        {
                            ProcessHandlers.Remove(processHandler);
                        }
                    }
                    else
                    {
                        // todo smarter handling of this case (try again in next loop, put to sleep, etc)
                        Logger.Error("Process {0} was {1} but could not be successfully killed ", processHandler.Name, reason);
                    }
                }
            }
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
                Debug.WriteLine($"HandleProcessNotRunning - processHandler.CallExecutable(ApplicationPath:{ApplicationPath}, ");
                processHandler.CallExecutable(ApplicationPath, "");
                ProcessHandlers.Add(processHandler);
            }
        }

        private void HandleExitedProcesses()
        {
            for (int index = 0; index < ProcessHandlers.Count; index++)
            {
                var processHandler = ProcessHandlers[index];
                if (processHandler.HasExited)
                {
                    Logger.Warn("Process {0} has exited", processHandler.Name);
                    processHandler.Close();

                    var notEnoughProcesses = (ProcessNo(processHandler.Name) < MinProcesses);
                    var lessProcessesThanBefore = (ProcessNo(processHandler.Name) < MaxProcesses) && KeepExistingNoProcesses;

                    if (notEnoughProcesses || lessProcessesThanBefore)
                    {
                        if (notEnoughProcesses) Logger.Info("Process {0} has exited and no others are running, so start new", processHandler.Name);
                        if (lessProcessesThanBefore) Logger.Info("Process {0} has exited, and number of processed needs to maintained , so start new", processHandler.Name);
                        Debug.WriteLine($"HandleExitedProcesses - processHandler.CallExecutable() ");
                        processHandler.CallExecutable();

                    }
                    else
                    {
                        Logger.Info("Process {0} has exited, but no requirement to start new one", processHandler.Name);
                        Debug.WriteLine($"HandleExitedProcesses - ProcessHandlers.Remove(processHandler); ");
                        ProcessHandlers.Remove(processHandler);
                    }

                }
            }
        }
        private int ProcessNo(string applicationName)
        {
            return Process.GetProcessesByName(applicationName).Length;
        }
    }
}
