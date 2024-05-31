using System.Net.Mail;

namespace ValconLibrary.EmailService
{
    public class Email
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public AlternateView Body { get; set; }
        public string AttachmentPath { get; set; }
    }
}
