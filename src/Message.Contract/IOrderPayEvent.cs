using System;

namespace Message.Contract
{
    public interface IOrderPayEvent 
    {
        string Id { get; }
        Guid CorrelationId { get; }
        string OrderStatus { get; }
    }

}
