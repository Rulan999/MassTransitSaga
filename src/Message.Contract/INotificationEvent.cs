using System;

namespace Message.Contract
{
    public interface INotificationEvent 
    {
        string Id { get; }
        Guid CorrelationId { get; }
        string OrderStatus { get; }
    }

}
