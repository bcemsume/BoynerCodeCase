using Core.Context;
using Core.Repository;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class MongoConfigDal : MongoDBRepositoryBase<Config, MongoContext<Config>>, IConfigDal
    {
    }
}
