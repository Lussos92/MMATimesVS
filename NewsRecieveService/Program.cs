using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace NewsRecieveService
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("create-story-queue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(message);
                    };

                    channel.BasicConsume("", true, consumer);

                    var message = new { Name = "Producer", Message = "Hello!" };
                    var body = Encoding.UTF8.GetBytes("This is a test string");

                    channel.BasicPublish("", "create-story-queue", null, body);
                }
            }
        }
    }
}
