using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTemplate.DataBase
{
    interface ISqlStatement
    {
        void insert(string content, string url);
        void update();
        void delete();
        void read();
    }
}
