using Message.Contract;
using System;

namespace Microservice.Order.Publisher.Models
{
    public class OrderViewModel : IOrder
    {
        public DateTime OrderDate { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public string Id => Guid.NewGuid().ToString();
    }

}
