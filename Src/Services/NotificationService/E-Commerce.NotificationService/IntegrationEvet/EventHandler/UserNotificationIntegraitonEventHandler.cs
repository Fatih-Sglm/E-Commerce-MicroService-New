using E_Commerce.NotificationService.IntegrationEvet.Event;
using MassTransit;

namespace E_Commerce.NotificationService.IntegrationEvet.EventHandler
{
    public class UserNotificationIntegrationEventHandler : IConsumer<UserNotificationIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<UserNotificationIntegrationEvent> context)
        {
            await Console.Out.WriteLineAsync("Hello World");
        }
    }
}
