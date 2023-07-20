using System.Text;

namespace E_Commerce.NotificationService.MailMessages
{
    public static class OrderMessage
    {
        public static string OrderFailedMessage(string FullName, string OrderNumber, string? ErrorMessage)
        {
            return new StringBuilder().AppendFormat($"Merhabalar sayın {FullName}, <br/> " +
                $"{OrderNumber} numaralı siparişiniz {ErrorMessage} nedeniyle tamamlanamamıştır").ToString();
        }
    }
}
