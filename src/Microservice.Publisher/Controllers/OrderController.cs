using MassTransit;
using Message.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microservice.Order.Publisher.Models;

namespace Microservice.Order.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel model)
        {
            if (model is not null)
            {
                Uri uri = new Uri($"{RabbitMqConsts.RabbitMqRootUri}/{RabbitMqConsts.queueName}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send<IOrder>(new
                {
                    Id = model.Id,
                    OrderDa = model.OrderDate,
                    Qty = model.Qty,
                    Price = model.Price
                });

                return Ok();
            }
            return BadRequest();
        }
    }
}