using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTemplate.Worker
{
    class ServiceWorker : IServiceWorker
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ServiceWorker));

        private string name;

        public ServiceWorker(string name)
        {
            this.name = name;
        }


        public void doWork()
        {
            logger.Info("Start do work " + Name);
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
