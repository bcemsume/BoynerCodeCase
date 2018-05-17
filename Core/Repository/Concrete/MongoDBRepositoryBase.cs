using Core.Context;
using Core.Entity;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class MongoDBRepositoryBase<TEntity, TMongoClient> : IRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TMongoClient : MongoContext<TEntity>, new()
    {
        TMongoClient _client;

        public MongoDBRepositoryBase()
        {
            _client = new TMongoClient();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _client.Db.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _client.Db.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await _client.Db.AsQueryable<TEntity>().ToListAsync();

            return await _client.Db.AsQueryable().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await _client.Db.AsQueryable().FirstOrDefaultAsync();

            return await _client.Db.AsQueryable().FirstOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(Expression<Func<TEntity, bool>> filter, TEntity entity)
        {
            var result = await _client.Db.ReplaceOneAsync(filter, entity);
        }

    }
}
