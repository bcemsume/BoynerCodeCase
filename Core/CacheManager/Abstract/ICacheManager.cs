using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CacheManager.Abstract
{
    public interface ICacheManager
    {
        object GetValue(string key);

        Task<object> GetValueAsync(string key);

        void SetValue(string key);

        Task SetValueAsync(string key);

    }
}
