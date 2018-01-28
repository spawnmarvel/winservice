using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTemplate.DataBase
{
    class SqlStatement : ISqlStatement
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SqlStatement));
        private DataBaseConnection con;
        public SqlStatement()
        {
            con = new DataBaseConnection();
        }
        public void delete()
        {
            throw new NotImplementedException();
        }

        public void insert(string data)
        {
            con.openDb();
            logger.Info("Insert arrived : " + data);
            logger.Info("Insert completed");
            con.closeDb();
            
        }

        public void read()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
