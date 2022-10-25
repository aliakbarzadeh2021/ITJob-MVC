namespace ITJob.Infrastructure.Configuration
{
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings _applicationSettings;

        public static void InitializeApplicationSettingsFactory(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return _applicationSettings;
        }

		//public static string DefaultConnectionString
		//{
		//	get { return @"Data Source=192.168.3.112;Initial Catalog=ECG;Persist Security Info=True;Integrated Security=False;User ID=sa;Password=P@ssw0rd;Connect Timeout=15"; }
		//}
    }
}
