using System;

namespace Message.Contract
{
    public interface IOrderPaidEvent 
    {
        string Id { get; }
        Guid CorrelationId { get; }
      
        string OrderStatus { get; }
    }

}
