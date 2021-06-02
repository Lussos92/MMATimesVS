using DatabaseLayer.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MMATimes.Models;
using NewsService.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewsConsumeService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        private bool SaveStoryToDatabase(string message)
        {
            var context = new MMATimes_MainContext();
            var deserializedNewsStory = JsonConvert.DeserializeObject<NewsStory>(message);
            NewsStory newsStory = new NewsStory
            {
                Blurb = deserializedNewsStory.Blurb,
                MainBody = deserializedNewsStory.MainBody,
                Title = deserializedNewsStory.Title
            };

            try
            {
                context.Add(newsStory);
                context.SaveChanges();
            }

            catch(Exception ex)
            {
                _logger.LogError("Error saving to Database " + ex.Message);
                return false;
            }

            _logger.LogInformation("Saved to Database");

            return true;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            _logger.LogInformation("Creating Connection to RabbitMQ");
            using var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("create-story-queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                var message = string.Empty;
                consumer.Received += (sender, e) =>
                {
                    try
                    {
                        var body = e.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);
                        if (!SaveStoryToDatabase(message))
                        {
                            Console.WriteLine("Error: Message Not Saved To Database" + message);
                        }
                        else
                        {
                            Console.WriteLine(message);
                            _logger.LogInformation(message);
                        }
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError("Error: " + ex.Message);
                    }
                };

                _logger.LogInformation("Consumer Recieved");
                channel.BasicConsume("", true, consumer);
                _logger.LogInformation("Message Consumed");
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10, stoppingToken);
            }
        }

        private void HandleMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}

