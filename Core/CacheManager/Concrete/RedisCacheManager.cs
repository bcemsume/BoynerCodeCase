using Core.CacheManager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using System.Threading.Tasks;
using Common.Extensions;

namespace Core.CacheManager.Concrete
{
    public class RedisCacheManager : ICacheManager
    {
        private static IDatabase _database;

        public RedisCacheManager()
        {
            var connection = RedisConnectionFactory.GetConnection();

            _database = connection.GetDatabase();
        }
        public object GetValue(string key)
        {
            return _database.StringGet(key);
        }

        public async Task<object> GetValueAsync(string key)
        {
            return (await _database.StringGetAsync(key));
        }

        public void SetValue(string value)
        {
            _database.StringSet("test", value);
        }

        public Task SetValueAsync(string value)
        {
            throw new NotImplementedException();
        }
    }
}
