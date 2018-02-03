using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ServiceWorker(string name)
        {
            this.name = name;
            controller = new ControlWorker();
        }

       

        public void doWork()
        {
            logger.Info("Start do work Service: " + Name);
            controller.insertDb("Second content", "myurl");

        }

        public void stopWork()
        {
            logger.Info("Stop do work " + Name);
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
