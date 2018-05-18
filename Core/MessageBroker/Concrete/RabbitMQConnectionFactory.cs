using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MessageBroker.Concrete
{
    public class RabbitMQConnectionFactory
    {
        private readonly string _hostName = @"https://hound.rmq.cloudamqp.com/";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostName
            };

            return connectionFactory.CreateConnection();
        }
    }
}
