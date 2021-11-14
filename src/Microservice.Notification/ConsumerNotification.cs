using MassTransit;
using Message.Contract;
using System;
using System.Threading.Tasks;

namespace Microservice.Notification
{
    public class ConsumerNotification : IConsumer<INotificationEvent>
    {
        public async Task Consume(ConsumeContext<INotificationEvent> context)
        {
            await Console.Out.WriteLineAsync($"Notification received: status -> {context.Message.OrderStatus}");

          
        }
    }
}