namespace ITJob.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string DefaultConnectionstring { get; }
        int NumberOfResultsPerPage { get; }
		string StartupPath { get; }
    }
}
