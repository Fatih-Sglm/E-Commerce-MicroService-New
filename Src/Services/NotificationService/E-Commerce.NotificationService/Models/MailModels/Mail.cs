using MimeKit;

namespace E_Commerce.NotificationService.Models.MailModels
{
    public class Mail
    {
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public bool IsHtml { get; set; }
        public AttachmentCollection? Attachments { get; set; }
        public string ToFullName { get; set; }
        public string ToEmail { get; set; }
        public Mail(string subject, string textBody, bool isHtml, AttachmentCollection? attachments, string toFullName, string toEmail)
        {
            Subject = subject;
            TextBody = textBody;
            IsHtml = isHtml;
            Attachments = attachments;
            ToFullName = toFullName;
            ToEmail = toEmail;
        }
    }
}
