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
                // RabbitMQ'nun bağlantı kuracağı host'u tanımlıyoruz. Herhangi bir güvenlik önlemi koymak istersek, Management ekranından password adımlarını tanımlayıp factory içerisindeki "UserName" ve "Password" property'lerini set etmemiz yeterlidir.
                HostName = _hostName
            };

            return connectionFactory.CreateConnection();
        }
    }
}
