using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITJob.MVC.Startup))]
namespace ITJob.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
