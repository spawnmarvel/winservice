using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTemplate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // By default, the current directory for your Windows service is the System32 folder.  I keep forgetting that which causes me problems when I try to access a file or folder using a relative path.
            System.IO.Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            //Use the above line of code to set the current directory to the same directory as your windows service. Don’t say I didn’t warn you. I shall never forget again.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceTemplate()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
