namespace Message.Contract
{
    public class RabbitMqConsts
    {
        public const string RabbitMqRootUri = "rabbitmq://localhost";
        public const string queueName = "orderQueue";
        public const string paymentqueueName = "orderQueue-payment";
        public const string notifqueueName = "orderQueue-notif";
        public const string sagaqueueName = "orderQueue-saga";
        public const string registerqueueName = "orderQueue-register";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string NotificationServiceQueue = "notification.service";
    }
}
