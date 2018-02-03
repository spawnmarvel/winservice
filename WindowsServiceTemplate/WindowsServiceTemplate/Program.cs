using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
//project
using WindowsServiceTemplate.Worker;

namespace WindowsServiceTemplate
{
    static class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application as a service
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
            //ServiceBase.Run(ServicesToRun);
            //added
           
            if (Environment.UserInteractive)
            {
                RunInteractive(ServicesToRun);
            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
        }

        ///run as console application:
        ///
        static void RunInteractive(ServiceBase[] servicesToRun)
        {
            ServiceWorker testWorker = new ServiceWorker("Test worker CA");
            Console.WriteLine(testWorker.Name + " Running in interactive mode");

            //start it
            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart",
               BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Starting " + service.ServiceName + "\n");
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                Console.Write("Started\n");

            }
            testWorker.doWork();
            Console.WriteLine("Press any key to stop the service and end the process\n");
            Console.ReadKey();

            //stop it
            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("\nStopping " + service.ServiceName + "\n");
                onStopMethod.Invoke(service, null);
                Console.WriteLine("Stopped\n");
            }
            testWorker.stopWork();
            Console.WriteLine("Service stopped, CMD will exit in 10 sec");
            System.Threading.Thread.Sleep(10000);

        }
    }
   
}
