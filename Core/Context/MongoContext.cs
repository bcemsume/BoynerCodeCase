using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Context
{
    public class MongoContext<T>
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext()
        {
            var client = new MongoClient("mongodb://51.15.81.157:27017/");
            if (client != null)
                _database = client.GetDatabase("Boyner");
        }

        public IMongoCollection<T> Db
        {
            get
            {
                return _database.GetCollection<T>(typeof(T).Name);
            }
        }

        public IMongoCollection<T> HistoryDb
        {
            get
            {
                return _database.GetCollection<T>(string.Format("{0}_{1}", typeof(T).Name, "History"));
            }
        }

    }

}
