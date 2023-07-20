using System.Text;

namespace E_Commerce.NotificationService.MailMessages
{
    public class UserMessage
    {
        public static string ResetPasswordMailMessage
            (string clientUrl, string urlRoute, string fullName, string userId, string token)
            => new StringBuilder()
            .AppendFormat("Merhabalar sayın {0} Şifrenizi Aşağıda verilmiş olan link üzerinden güncelleyebilirsiniz " +
                "Eğer Bu talebi siz oluşrmadıysanız lütfen bize bildiriniz <br/>  <br/> " +
                "<a target=\"_blank\" href=\"{1}/{2}/{3}/{4}\" >Şifenizi doğrulamak için Tıklayınız</a>",
                fullName, clientUrl, urlRoute, userId, token).ToString();

        public static string ConfirmMailMessage
            (string clientUrl, string urlRoute, string fullName, string userId, string token)
            => new StringBuilder()
            .AppendFormat("Merhabalar sayın {0} Sistemizi Kullanmaya devam edebilmeniz için Mail Adresinizin Doğrulanması Gerekmektedir " +
                "Lütfen aşağıdaki linkten Mail Adresini Güncelleyiniz <br/>  <br/> " +
                "<a target=\"_blank\" href=\"{1}/{2}/{3}/{4}\" >Mailiniz Doğrulamak için Tıklayınız</a>",
                fullName, clientUrl, urlRoute, userId, token).ToString();

    }
}
