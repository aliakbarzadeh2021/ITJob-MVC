using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.Host.Api.ServiceHost;
using Topshelf;

namespace ITJob.Host.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHostFactory.Run();
        }
    }
}
