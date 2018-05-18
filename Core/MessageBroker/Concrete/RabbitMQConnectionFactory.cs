using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MessageBroker.Concrete
{
    public class RabbitMQConnectionFactory
    {
        private readonly string _hostName = @"amqp://51.15.81.157:5672/";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(_hostName),
                Password = "guest",
                UserName = "guest",
                //VirtualHost = "/",
                //Port = AmqpTcpEndpoint.UseDefaultPort,
                //HostName = "51.15.81.157"
            };

            //connectionFactory.RequestedHeartbeat

            return connectionFactory.CreateConnection();
        }
    }
}
