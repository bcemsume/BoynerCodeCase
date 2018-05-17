using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IConfigService
    {
        Task<Config> GetAsync(Expression<Func<Config, bool>> filter = null);
        Task<IEnumerable<Config>> GetAllAsync(Expression<Func<Config, bool>> filter = null);
        Task DeleteAsync(Expression<Func<Config, bool>> filter);
        Task UpdateAsync(Expression<Func<Config, bool>> filter, Config entity);
        Task AddAsync(Config entity);
    }
}
