using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CacheManager.Abstract
{
    public interface ICacheManager<T>
    {
        T GetValue(string key);

        Task<T> GetValueAsync(string key);

        void SetValue(string key);

        Task SetValueAsync(string key);

    }
}
