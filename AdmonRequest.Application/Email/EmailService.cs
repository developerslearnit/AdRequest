using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net;

namespace AdmonRequest.Application.Email
{
    /// <summary>
    /// Requires https://www.nuget.org/packages/SendGrid package
    /// </summary>
    public class EmailService 
    {
        private readonly string _apiKey;
        private readonly string _fromEmail;
        private readonly string _fromDisplayName;
       

        public EmailService(string apiKey, string fromEmail, string fromDisplayName)
        {
            _apiKey = apiKey;
            _fromEmail = fromEmail;
            _fromDisplayName = fromDisplayName;
        }

        public async Task<Tuple<bool, string>> SendEmailAsync(string subject, string toEmail, string body, string attachmentName = null, string attachment = null, string cc = null, string bcc = null)
        {
            var mailClient = new SendGridClient(_apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_fromEmail, _fromDisplayName),
                Subject = subject,
                HtmlContent = body
            };

            if (!string.IsNullOrWhiteSpace(attachment))
            {
                message.AddAttachment(attachmentName, attachment);
            }

            var toEmails = toEmail.Contains(";") ? toEmail.Split(';') : toEmail.Split(',');

            var emailList = toEmails.Select(x => new EmailAddress(x)).ToList();

            message.AddTos(emailList);

            if (!string.IsNullOrWhiteSpace(cc))
            {
                var ccEmails = cc.Contains(";") ? cc.Split(';') : cc.Split(',');
                var ccList = ccEmails.Select(x => new EmailAddress(x)).ToList();
                message.AddCcs(ccList);
            }

            if (!string.IsNullOrWhiteSpace(bcc))
            {
                var bccEmails = bcc.Contains(";") ? bcc.Split(';') : bcc.Split(',');
                var bccList = bccEmails.Select(x => new EmailAddress(x)).ToList();
                message.AddCcs(bccList);
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, errors) =>
            {
                return true;
            };

            var response = await mailClient.SendEmailAsync(message);

            bool status = response.StatusCode.ToString() == "Accepted" ? true : false;

            return Tuple.Create(status, response.StatusCode.ToString());


        }
    }
}
