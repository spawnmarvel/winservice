using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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

        public void insert(string content, string url)
        {
           
            try
            {
                con.openDb();
                logger.Info("Insert arrived : " + content + " " + url);
                NpgsqlCommand cmd = con.getConnection().CreateCommand();
                string sql = "insert into data_collector (data_content, data_url) values ('" + content + "','" + url + "'" + ");";
                logger.Info("\n" + sql);
                cmd.CommandText = sql;
                int rows = cmd.ExecuteNonQuery();
                logger.Info("Insert status " + rows);
                con.closeDb();
            }
            catch (NpgsqlException msg)
            {
                logger.Error(msg);
            }
            catch (Exception msg)
            {
                logger.Error(msg);
            }
            
            
            
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
