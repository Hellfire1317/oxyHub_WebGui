using System;
using System.Diagnostics;

namespace shellCommands
{
    public class hostapd
    {
        void RunCommand()
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "systemctl",
                    Arguments = "restart hostapd",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = true,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
        }
    }

}