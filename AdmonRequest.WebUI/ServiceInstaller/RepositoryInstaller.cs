using AdmonRequest.Application.Email;
using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Services;
using AdmonRequest.Persistence.Repository;

namespace AdmonRequest.WebUI.ServiceInstaller
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();
            builder.Services.AddScoped<IAppRepository, AppRepository>();
            builder.Services.AddScoped<IAppService, AppService>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IMailNotification, MailNotification>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            
        }
    }
}



