using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceTemplate;
using WindowsServiceTemplate.DataBase;

namespace WindowsServiceTemplate.Controller
{
    class ControlWorker
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ControlWorker));
        private SqlStatement sql;
       
        /// <summary>
        /// Controlls the process for service worker, handles db etc
        /// </summary>
        public ControlWorker()
        {
            sql = new SqlStatement();
            logger.Info("Setup new SQL store");
           
        }

        public void insertDb(string content, string url)
        {
           logger.Info(content + " " + url);
           sql.insert(content, url);
            try
            {
                //sql.read();
            }
            catch (Exception msg)
            {
                logger.Error(msg);
            }


        }
    }
}
