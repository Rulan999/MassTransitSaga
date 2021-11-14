using MassTransit;
using Message.Contract;
using System;
using System.Threading.Tasks;

namespace Microservice.Payment
{
    public class ConsumerPayment : IConsumer<IOrderPayEvent>
    {
        public async Task Consume(ConsumeContext<IOrderPayEvent> context)
        {
            await Console.Out.WriteLineAsync($"Payment received: status -> {context.Message.OrderStatus}");
            await context.Publish<IOrderPaidEvent>(
             new
             {
                 CorrelationId = context.Message.CorrelationId,
                 Id = context.Message.Id,
                 OrderStatus = "OrderPaid"
             });
            
        }
    }
}