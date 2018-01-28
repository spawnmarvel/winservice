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
       

        public ControlWorker()
        {
            sql = new SqlStatement();
            logger.Info("Setup new SQL store");
           
        }

        public void insertDb(string data)
        {
           logger.Info(data);
           sql.insert(data);
        }
    }
}
