using GreenPipes;
using MassTransit;
using Message.Contract;
using System;

namespace Microservice.Notification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Notification Service";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqRootUri), h =>
                {
                    h.Username(RabbitMqConsts.UserName);
                    h.Password(RabbitMqConsts.Password);
                });
                cfg.ReceiveEndpoint(RabbitMqConsts.notifqueueName, ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.Consumer<ConsumerNotification>();
                });

            });

            bus.StartAsync();
            Console.WriteLine("Listening for Order notification events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
