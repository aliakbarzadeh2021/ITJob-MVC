using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace ITJob.Host.Api.ServiceHost
{
    public class ServiceHost
    {
        private IDisposable _webApp;

        public string BaseAddress => "http://localhost:9000/";

        public void Start()
        {
            _webApp = WebApp.Start<Startup>(BaseAddress);
        }

        public void Stop()
        {
            _webApp.Dispose();
        }
    }
}
