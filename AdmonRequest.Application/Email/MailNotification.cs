using AdmonRequest.Application.Email;
using AdmonRequest.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AdmonRequest.Application.Email
{
    public class MailNotification : IMailNotification
    {
        
        private readonly IConfiguration _configuration;
        private readonly INotificationService _mailService;
        public MailNotification(IConfiguration config, INotificationService mailService)
        {
            _configuration = config;
            _mailService = mailService;
        }

        public void QueueEmail(Guid emailId)
        {
            var apiKey = _configuration.GetSection("EMailAPIKey").Value;
            var emailFromDisplayName = _configuration.GetSection("EMailFromDisplayName").Value;
            var mail = _mailService.FetchAllNotifications().Where(x=>x.EmailWorkerId==emailId).FirstOrDefault();

            if (mail != null)
            {
                var emailService = new EmailService(apiKey, mail.FromAddress, emailFromDisplayName);

                var mailStatus = emailService.SendEmailAsync(mail.Subject, mail.ToAddress, mail.Body).GetAwaiter().GetResult();

                var sentStatus = mailStatus.Item1;

                if (sentStatus)
                {
                    _mailService.UpdateNotification(emailId).GetAwaiter().GetResult();
                }
            
            }

        }

      
    }
}
