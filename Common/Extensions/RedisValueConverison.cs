using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class RedisValueConverison
    {
        public static T ConvertValue<T>(this RedisValue source)
        {
            return (T)Convert.ChangeType(source, typeof(T));
        }
    }
}
