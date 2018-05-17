using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MessageBroker.Abstract
{
    public interface IMessageBroker
    {
        void Publisher(string queueName, string message);
        void Consumer(string queueName);
    }
}
