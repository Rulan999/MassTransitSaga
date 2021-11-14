using Message.Contract;
using System;

namespace Microservice.Order
{
    public class OrderPayEvent: IOrderPayEvent
    {
        private readonly OrderSagaState orderSagaState;

        public OrderPayEvent(OrderSagaState orderSagaState)
        {
            this.orderSagaState = orderSagaState;
        }

        public Guid CorrelationId => orderSagaState.CorrelationId;

        public string OrderStatus => orderSagaState.OrderStatus;

        public string Id => orderSagaState.Id;
    }
}