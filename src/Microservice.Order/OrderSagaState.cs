using System;
using Automatonymous;

namespace Microservice.Order
{
    public class OrderSagaState: SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public  string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string OrderStatus { get; set; }
    }
}