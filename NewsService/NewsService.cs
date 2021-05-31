using NewsService.Controllers;
using NewsService.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsService
{
    public class NewsService
    {
        public static void PostNewsArticle(NewsPost newsPost)
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
                    var message = new { Name = "Producer", Message = "Hello!" };
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(newsPost));

                    channel.BasicPublish("", "create-story-queue", null, body);
                }
            }
        }
    }
}
