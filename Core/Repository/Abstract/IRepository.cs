using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task DeleteAsync(Expression<Func<T, bool>> filter);
        Task UpdateAsync(Expression<Func<T, bool>> filter, T entity);
        Task AddAsync(T entity);

    }
}
