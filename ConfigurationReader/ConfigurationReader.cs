using Core.CacheManager.Abstract;
using Core.CacheManager.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reader
{
    
    public class ConfigurationReader
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

            _container = new Container();

            _container.Register<IConfigDal, MongoConfigDal>();
            _container.Register<ICacheManager<string>, RedisCacheManager<string>>();
            _container.Verify();
        }

        public void Get()
        {
            var redis = _container.GetInstance<ICacheManager<string>>();

            redis.SetValue("test123123");

           var value =  redis.GetValue("test");
        }
    }
}
