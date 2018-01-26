﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
//project
using WindowsServiceTemplate.Worker;

namespace WindowsServiceTemplate
{
    public partial class ServiceTemplate : ServiceBase
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ServiceTemplate));
        private ServiceWorker serviceWorker;

        public ServiceTemplate()
        {
            InitializeComponent();
            serviceWorker = new ServiceWorker("Jinbot");

        }

        protected override void OnStart(string[] args)
        {
            logger.Info("********************");
            logger.Info("Service started main");
            serviceWorker.doWork();
        }

        protected override void OnStop()
        {
            serviceWorker.stopWork();
            logger.Info("Service stopped main");

        }
    }
}
