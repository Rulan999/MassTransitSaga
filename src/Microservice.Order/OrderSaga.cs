using System;
using Automatonymous;
using Message.Contract;

namespace Microservice.Order
{
    public class OrderSaga : MassTransitStateMachine<OrderSagaState>
    {
        public State OrderPaid { get; private set; }
        public Event<IOrder> RegisteOrder { get; private set; }
        public Event<IOrderPaidEvent> PayOrder{ get; private set; }


        public OrderSaga()
        {
            InstanceState(s => s.CurrentState);

            Event(() => RegisteOrder, x => x.CorrelateById(context =>
               new Guid(context.Message.Id)));

            Event(() => PayOrder, x => x.CorrelateById(context =>
               context.Message.CorrelationId));

            Initially(
                When(RegisteOrder)
                    .Then(context =>
                    {
                        context.Instance.OrderDate = context.Data.OrderDate;
                        context.Instance.Qty = context.Data.Qty;
                        context.Instance.Price = context.Data.Price;
                        context.Instance.OrderStatus = "OrderRegistered";
                        context.Instance.Id = context.Data.Id;
                        Console.Out.WriteLineAsync($"Register Order for id {context.Data.Id} received ");
                        // calling order command to save db 
                    })
                    .Publish(context => new OrderPayEvent(context.Instance))
                    .TransitionTo(OrderPaid)
                );
            
            During(OrderPaid,
                When(PayOrder)
                   .Then(context =>
                   {
                       context.Instance.OrderStatus = context.Data.OrderStatus;
                       Console.Out.WriteLineAsync($"Pay Order for id {context.Data.Id} received with status {context.Data.OrderStatus}");

                   })
                    .If(context => context.Data.OrderStatus == "OrderPaid", x =>
                       x.Publish(context => new NotificationEvent(context.Instance)))
                   .Finalize()
                );

            SetCompletedWhenFinalized();
        }
    }
}