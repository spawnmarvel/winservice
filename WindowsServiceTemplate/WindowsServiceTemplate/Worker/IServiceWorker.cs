using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTemplate.Worker
{
    interface IServiceWorker
    {

        void doWork();
        void stopWork();

    }
}
