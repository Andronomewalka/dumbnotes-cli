using System.Diagnostics;

namespace DumbnotesCli
{
    public class CommandService
    {
        public void RunCommand(string command)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "wt.exe",
                Arguments = command
            };
            process.Start();
        }
    }
}
