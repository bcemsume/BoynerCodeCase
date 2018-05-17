using Core.CacheManager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using System.Threading.Tasks;
using Common.Extensions;

namespace Core.CacheManager.Concrete
{
    public class RedisCacheManager<T> : ICacheManager<T>
    {
        private static IDatabase _database;

        public RedisCacheManager()
        {
            var connection = RedisConnectionFactory.GetConnection();

            _database = connection.GetDatabase();
        }
        public T GetValue(string key)
        {
            return _database.StringGet(key).ConvertValue<T>();
        }

        public async Task<T> GetValueAsync(string key)
        {
            return (await _database.StringGetAsync(key)).ConvertValue<T>();

        }

        public void SetValue(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetValueAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
