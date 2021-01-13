using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;

namespace shellCommands
{
    public class controller
    {
        public void restartHostapd()
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "systemctl restart hostapd",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            
        }

        public bool PingSensor(IPAddress address)
        {
            bool result = false;
            var ping = new Ping();
            var reply = ping.Send(address);

            if (reply.Status== IPStatus.Success)
            {
                result = true;
            }
            return result;
        }

        public bool CheckService(string service)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "systemctl show -p ActiveState --value  " + service,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (output == "active")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

}