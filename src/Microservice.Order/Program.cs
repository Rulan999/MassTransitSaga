using GreenPipes;
using MassTransit;
using MassTransit.Saga;
using Message.Contract;
using System;

namespace Microservice.Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Order Service";
            var saga = new OrderSaga();
            var repo = new InMemorySagaRepository<OrderSagaState>();


            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
                {
                    h.Username(RabbitMqConsts.UserName);
                    h.Password(RabbitMqConsts.Password);
                });
                cfg.ReceiveEndpoint(RabbitMqConsts.queueName, ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.StateMachineSaga(saga, repo);
                });

            });

            bus.StartAsync();
            Console.WriteLine("Listening for Order Register events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
