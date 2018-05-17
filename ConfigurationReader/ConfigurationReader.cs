using DataAccess.Abstract;
using DataAccess.Concrete;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationReader
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

            _container.Verify();
        }
    }
}
