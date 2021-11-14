using GreenPipes;
using MassTransit;
using Message.Contract;
using System;

namespace Microservice.Payment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Payment Service";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
                {
                    h.Username(RabbitMqConsts.UserName);
                    h.Password(RabbitMqConsts.Password);
                });
                cfg.ReceiveEndpoint(RabbitMqConsts.paymentqueueName, ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.Consumer<ConsumerPayment>();
                });

            });

            bus.StartAsync();
            Console.WriteLine("Listening for ORder payment events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
