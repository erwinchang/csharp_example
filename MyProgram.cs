using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_example
{
    class MyProgram
    {
    }
    public class Example
    {
        public void Main()
        {
            Console.WriteLine("Example Main");
            List<string> names = ComPortNames("0403", "6001");
            foreach(String s in names)
            {
                Console.WriteLine($"-- name:{s}");
            }
            List<string> ports = FindPort();
        }

        //https://www.codeproject.com/Tips/349002/Select-a-USB-Serial-Device-via-its-VID-PID
        List<string> ComPortNames(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<String> comports = new List<String>();

            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach(String s3 in rk2.GetSubKeyNames())
            {
                Console.WriteLine($"s3:{s3}");
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach(String s in rk3.GetSubKeyNames())
                {
                    Console.WriteLine($"s:{s}");
                    if (_rx.Match(s).Success)
                    {
                        Console.WriteLine($"==Entry==");
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach(String s2 in rk4.GetSubKeyNames())
                        {
                            Console.WriteLine($"s2:{s2}");
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");                             
                            comports.Add((String)rk6.GetValue("PortName"));
                            String name = (String)rk6.GetValue("PortName");
                            Console.WriteLine($"**** name:{name}");
                        }
                    }
                }
            }
            return comports;
        }
        List<string> FindPort()
        {
            List<String> comports = new List<String>();

            ManagementObjectCollection ManObjReturn;
            ManagementObjectSearcher ManObjSearch;

            ManObjSearch = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            ManObjReturn = ManObjSearch.Get();

            foreach (ManagementObject ManObj in ManObjReturn)
            {
                //Name:Qualcomm HS-USB Diagnostics 9084 (COM5), Manufacturer:Qualcomm Incorporated
                //Name:USB Serial Port (COM4), Manufacturer:FTDI
                string name = ManObj["Name"].ToString();
                string man = ManObj["Manufacturer"].ToString();
                Console.WriteLine($"Name:{name}, Manufacturer:{man}");
            }
            return comports;
        }
    }
}
