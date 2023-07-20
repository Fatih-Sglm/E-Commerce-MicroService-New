using Microsoft.Extensions.Configuration;

namespace E_Commerce.IdentityService.Application.Helper
{
    public static class SystemMailMessages
    {
        public static string ConfirmMailMessageAsync(IConfiguration configuration, string urlRoute, string fullName, string userId, string token)
        {

            return $"Merhabalar sayın {fullName} <br/> Sistemizi Kullanmaya devam edebilmeniz için Mail Adresinizin Doğrulanması Gerekmektedir " +
                 $"Lütfen aşağıdaki linkten Mail Adresini Güncelleyiniz <br/>  <br/> " +
                 $"<a target=\"_blank\" href=\"{configuration["Urls:ClientUrl"]}/{urlRoute}/{userId}/{token}\" >Mailiniz Doğrulamak için Tıklayınız</a> ";
        }

        public static string ResetPasswordMailMessageAsync(IConfiguration configuration, string urlRoute, string fullName, string userId, string token)
        {

            return $"Merhabalar sayın {fullName} <br/> Şifrenizi Aşağıda verilmiş olan link üzerinden güncelleyebilirsiniz " +
                 $"Eğer Bu talebi siz oluşrmadıysanız bu mesajı dikkate almayabilirsiniz <br/>  <br/> " +
                 $"<a target=\"_blank\" href=\"{configuration["Urls:ClientUrl"]}/{urlRoute}/{userId}/{token}\" >Şifenizi doğrulamak için Tıklayınız</a> ";
        }
    }
}
