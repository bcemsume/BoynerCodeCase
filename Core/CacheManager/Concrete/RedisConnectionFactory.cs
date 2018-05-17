using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace Core.CacheManager.Concrete
{
    public class RedisConnectionFactory
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;

        private static readonly string REDIS_CONNECTIONSTRING = "51.15.81.157:6379";

        static RedisConnectionFactory()
        {
            //var config = new ConfigurationBuilder()
            //    .AddEnvironmentVariables()
            //    .Build();

            //var connectionString = config[REDIS_CONNECTIONSTRING];

            //if (connectionString == null)
            //{
            //    throw new KeyNotFoundException($"Environment variable for {REDIS_CONNECTIONSTRING} was not found.");
            //}

            var options = ConfigurationOptions.Parse(REDIS_CONNECTIONSTRING);
            options.AbortOnConnectFail = false;
            options.ResponseTimeout = int.MaxValue;
            options.SyncTimeout = int.MaxValue;

            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }

        public static ConnectionMultiplexer GetConnection() => Connection.Value;
    }
}
