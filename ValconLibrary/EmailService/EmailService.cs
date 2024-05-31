using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ValconLibrary.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public void SendEmailWithAttachment(Email email)
        {
            const string displayName = "Valcon Library Notification";
            var fromAddress = new MailAddress(_smtpSettings.FromEmail, displayName);

            using (var message = new MailMessage())
            {
                message.From = fromAddress;
                message.To.Add(email.ToEmail);
                message.Subject = email.Subject;
                message.AlternateViews.Add(email.Body);
                message.IsBodyHtml = true;

                if (!string.IsNullOrEmpty(email.AttachmentPath))
                {
                    var attachment = new Attachment(email.AttachmentPath);
                    attachment.ContentId = email.AttachmentPath;
                    message.Attachments.Add(attachment);
                }

                using (var smtpClient = new SmtpClient(_smtpSettings.Server))
                {
                    smtpClient.Port = _smtpSettings.Port;
                    smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
            }
        }
    }
}

