using System;

namespace Message.Contract
{
    public interface IOrder
    {
         string Id { get;  }
         DateTime OrderDate { get; }
         int Qty { get;  }
         decimal Price { get; }
    }

}
