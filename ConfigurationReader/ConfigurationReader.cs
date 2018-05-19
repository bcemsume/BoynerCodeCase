using Common.Extensions;
using Core.CacheManager.Abstract;
using Core.CacheManager.Concrete;
using Core.MessageBroker.Abstract;
using Core.MessageBroker.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reader
{
    
    public class ConfigurationReader : IConfigurationReader
    {
        private string _applicationName;
        private string _connectionString;
        private int _refreshTimerIntervalInMs;
        private Container _container;

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            _applicationName = applicationName;
            _connectionString = connectionString;
            _refreshTimerIntervalInMs = refreshTimerIntervalInMs;

            
        }

        public void Initialize()
        {
            _container = new Container();

            _container.Register<IConfigDal, MongoConfigDal>();
            _container.Register<ICacheManager, RedisCacheManager>();
            _container.Register<IMessageBroker, RabbitMQMessageBroker>();
            _container.Verify();
        }


        public T GetValue<T>(string key)
        {
            var cacheManager = _container.GetInstance<ICacheManager>();

            var value = cacheManager.GetValue(key);

            return value.Conversion<T>();
        }
    }
}
