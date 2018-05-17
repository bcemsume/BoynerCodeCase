using DataAccess.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service
{
    public class ConfigService : IConfigService
    {
        IConfigDal _configDal;
        public ConfigService(IConfigDal configDal)
        {
            _configDal = configDal;
        }

        public async Task AddAsync(Config entity)
        {
            await _configDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Expression<Func<Config, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Config>> GetAllAsync(Expression<Func<Config, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Config> GetAsync(Expression<Func<Config, bool>> filter = null)
        {
           return await _configDal.GetAsync(filter);
        }

        public async Task UpdateAsync(Expression<Func<Config, bool>> filter, Config entity)
        {
            throw new NotImplementedException();
        }
    }
}
