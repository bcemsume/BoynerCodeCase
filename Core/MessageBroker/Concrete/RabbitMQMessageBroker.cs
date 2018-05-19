using Core.MessageBroker.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.MessageBroker.Concrete
{
    public class RabbitMQMessageBroker : IMessageBroker
    {
        private readonly RabbitMQConnectionFactory _rabbitMQConnectionFactory;

        public RabbitMQMessageBroker()
        {
            _rabbitMQConnectionFactory = new RabbitMQConnectionFactory();
        }

        public void Consumer(string queueName)
        {
            using (var connection = _rabbitMQConnectionFactory.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        Debug.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);
                    };

                    channel.BasicConsume(queueName, true, consumer);
                }
            }
        }

        public void Publisher(string queueName, string message)
        {
            using (var connection = _rabbitMQConnectionFactory.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));

                    Debug.WriteLine("{0} queue'su üzerine, \"{1}\" mesajı yazıldı.", queueName, message);
                }
            }
        }
    }
}
