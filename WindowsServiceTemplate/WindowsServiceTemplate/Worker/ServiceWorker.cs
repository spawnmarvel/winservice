using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsServiceTemplate;
using WindowsServiceTemplate.Controller;


namespace WindowsServiceTemplate.Worker
{
    class ServiceWorker : IServiceWorker
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ServiceWorker));
        private ControlWorker controller;
        private string name;
        private bool stop;

        Thread singelThread;
        public ServiceWorker(string name)
        {
            this.name = name;
            stop = false;
        }

       

        public void work()
        {
            controller = new ControlWorker();
            int x = 0;
            logger.Info("Stop = " + stop);
            while(stop == false)
            {
                logger.Info("Start do work Service: " + Name);
                controller.insertDb(x + " content", "myurl");
                x++;
                System.Threading.Thread.Sleep(1000 * 4);
            }
           
           

        }

        public void startWork()
        {
            singelThread = new Thread(work);
            singelThread.Name = "Sub Thread";
            singelThread.Start();
            logger.Info("Started " + singelThread.Name + " info " + singelThread.ToString() + " is it alive? " + singelThread.IsAlive);
        }

        public void stopWork()
        {
            logger.Info("Stopping " + singelThread.Name + " info " + singelThread.ToString() + " is it alive? " + singelThread.IsAlive);
            stop = true;
            singelThread.Join();
            logger.Info("Is the thread stopped? " + singelThread.Name + " info " + singelThread.ToString() + " is it alive? " + singelThread.IsAlive);

        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
