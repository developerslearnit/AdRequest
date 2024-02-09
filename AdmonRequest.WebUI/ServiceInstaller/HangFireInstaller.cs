using Hangfire;
using Hangfire.SqlServer;

namespace AdmonRequest.WebUI.ServiceInstaller
{
    public class HangFireInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHangfire(hangfire =>
            {
                hangfire.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
                hangfire.UseSimpleAssemblyNameTypeSerializer();
                hangfire.UseRecommendedSerializerSettings();
                hangfire.UseColouredConsoleLogProvider();
                hangfire.UseSqlServerStorage(
                             builder.Configuration.GetConnectionString("AppConnection"),
                    new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    });
            });

            builder.Services.AddHangfireServer();
        }
    }
}
