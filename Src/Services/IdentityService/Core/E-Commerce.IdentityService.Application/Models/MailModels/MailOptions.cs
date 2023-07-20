namespace E_Commerce.IdentityService.Application.Models.MailModels
{
    public class MailOptions
    {
        public required string Server { get; set; }
        public required int Port { get; set; }
        public required string SenderFullName { get; set; }
        public required string SenderEmail { get; set; }
        public required string Password { get; set; }
    }
}
