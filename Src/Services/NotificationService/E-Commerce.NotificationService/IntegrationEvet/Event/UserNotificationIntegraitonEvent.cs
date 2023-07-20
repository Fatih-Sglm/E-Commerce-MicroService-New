namespace E_Commerce.NotificationService.IntegrationEvet.Event
{
    public class UserNotificationIntegrationEvent
    {
        public required string UrlRoute { get; init; }
        public required string FullName { get; init; }
        public required string UserId { get; init; }
        public required string Email { get; init; }
        public required string Token { get; init; }
        public MessageType MessageType { get; init; }
    }

    public enum MessageType
    {
        ResetPassword,
        VerifyEmail
    }
}
