using System;
using Message.Contract;

namespace Microservice.Order
{
    public class NotificationEvent : INotificationEvent
    {
        private readonly OrderSagaState orderSagaState;

        public NotificationEvent(OrderSagaState orderSagaState)
        {
            this.orderSagaState = orderSagaState;
        }

        public Guid CorrelationId => orderSagaState.CorrelationId;

        public string OrderStatus => orderSagaState.OrderStatus;

        public string Id => orderSagaState.Id;
    }
}