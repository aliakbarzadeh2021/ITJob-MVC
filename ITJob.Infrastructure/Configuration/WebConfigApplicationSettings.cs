using System;
using System.Configuration;
using System.Reflection;
using System.Web.Configuration;
using ITJob.Infrastructure.Configuration;

namespace ITJob.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        private System.Configuration.Configuration _configuration;
        public WebConfigApplicationSettings()
        {
            _configuration = WebConfigurationManager.OpenWebConfiguration("/");
        }

        public string DefaultConnectionstring
        {
			get { return ConfigurationManager.ConnectionStrings["RazConnection"].ToString(); }
        }

        public int NumberOfResultsPerPage
        {
            get
            {
                int t;
                Int32.TryParse(ConfigurationManager.AppSettings["NumberOfResultsPerPage"], out t);

                return t == 0 ? 15 : t;
            }
        }

		public string StartupPath
		{
			get
			{
				var startupPath = ConfigurationManager.AppSettings["StartupPath"];
				if (string.IsNullOrWhiteSpace(startupPath))
				{
					try
					{
						startupPath = Assembly.GetExecutingAssembly().Location;
					}
					catch (Exception e)
					{

					}
				}
				return startupPath;
			}
		}
    }
}
