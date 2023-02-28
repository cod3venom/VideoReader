using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoReader.Adapter.Shell
{
    public class ShellAdapter
    {
        public event EventHandler<string> OnCmdResponseReturned;
        public event EventHandler<Exception> OnCMDExeptionOccured;

        public ShellAdapter() 
        {
        
        }

        public string Execute(string fileName, string arguments)
        {
            try
            {
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = fileName;
                pProcess.StartInfo.Arguments = arguments;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WorkingDirectory = string.Format(@"{0}\FFMPEG", Environment.CurrentDirectory);
                pProcess.Start();

                string strOutput = pProcess.StandardOutput.ReadToEnd();
                pProcess.WaitForExit();

                this.OnCmdResponseReturned?.Invoke(this, strOutput);
                return strOutput;
            }
            catch(Exception exception)
            {
                this.OnCMDExeptionOccured?.Invoke(this, exception);
                return exception.ToString();
            }
        }
    }
}
