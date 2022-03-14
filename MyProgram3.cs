﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram3
    {
    }

    //https://dotblogs.com.tw/wellwind/2016/05/22/csharp-observer-pattern-delegate-event
    public interface ITempatureMonitorSubject
    {
        void RegisterObserver(ITempatureMonitorObserver observer);
        void UnregisterObserver(ITempatureMonitorObserver observer);
        void NotifyTempature();
    }

    public interface ITempatureMonitorObserver
    {
        void OnTempatureChanged(double tempature);
    }

    public class TempatureMonitorSubject : ITempatureMonitorSubject
    {
        private double tempature;
        private List<ITempatureMonitorObserver> observers;
        public double Tempature
        {
            get { return tempature; }
            set
            {
                var oldTempature = tempature;
                if (oldTempature != value)
                {
                    tempature = value;
                    NotifyTempature();
                }
            }
        }
        public TempatureMonitorSubject()
        {
            observers = new List<ITempatureMonitorObserver>();
            Console.WriteLine("開始偵測溫度");
        }
        public void RegisterObserver(ITempatureMonitorObserver observer)
        {
            observers.Add(observer);
        }
        public void UnregisterObserver(ITempatureMonitorObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyTempature()
        {
            foreach (var observer in observers)
            {
                observer.OnTempatureChanged(tempature);
            }
        }
    }

    public class DesktopApp : ITempatureMonitorObserver
    {
        public void OnTempatureChanged(double tempature)
        {
            Console.WriteLine($"Desktop App被通知溫度變化了: {tempature}");
        }
    }

    public class MobileApp : ITempatureMonitorObserver
    {
        public void OnTempatureChanged(double tempature)
        {
            Console.WriteLine($"Mobile App被通知溫度變化了: {tempature}");
        }
    }

    public class TempatureMonitorSubjectTester
    {
        public void Main()
        {
            Console.WriteLine("Observer Pattern Demo");
            var tempatureMonitor = new TempatureMonitorSubject();

            var desktopApp = new DesktopApp();
            var mobileApp = new MobileApp();

            tempatureMonitor.RegisterObserver(desktopApp);
            tempatureMonitor.RegisterObserver(mobileApp);
            tempatureMonitor.Tempature = 30.5;
            tempatureMonitor.Tempature = 30.5;
            tempatureMonitor.Tempature = 28.6;
            tempatureMonitor.UnregisterObserver(mobileApp);
            tempatureMonitor.Tempature = 27.2;
        }
    }
}
