using E_Commerce.NotificationService.Models.MailModels;

namespace E_Commerce.NotificationService.Services.Abstract
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(Mail mail);
    }
}
