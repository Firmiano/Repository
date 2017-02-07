using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Attributes;
using Data.Domain;
using Data.Repository.Base.Interfaces;
using MongoDB.Driver;

namespace Data.Repository.Base
{
    public class MongoRepositoryBase<T> : IDisposable, IRepositoryBaseAsync<T> where T : DocumentBase
    {
        private MongoClient _client;
        private readonly IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        private IEnumerable<object> Attributes
        {
            get
            {
                var info = typeof(T);
                return info.GetCustomAttributes(true);
            }
        }

        public MongoRepositoryBase()
        {
            _database = Connect();
            GetCollection();
        }

        public IMongoCollection<T> GetCollection()
        {
            _collection = _database.GetCollection<T>(GetCollectionName());
            return _collection;
        }

        private string GetCollectionName()
        {
            var attributes = Attributes;

            foreach (var attr in attributes)
            {
                var collectionAttr = attr as CollectionAttribute;
                if (collectionAttr != null)
                    return collectionAttr.Collection;
            }
            return typeof(T).Name;
        }

        private string GetDataBaseName()
        {
            var attributes = Attributes;

            foreach (var attr in attributes)
            {
                var collectionAttr = attr as DataBaseAttribute;
                if (collectionAttr != null)
                    return collectionAttr.DataBase;
            }
            return typeof(T).Name;
        }

        private IMongoDatabase Connect()
        {
            _client = new MongoClient("");
            var database = _client.GetDatabase(GetDataBaseName());
            return database;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<T> GetById(string id)
        {
            var query = Builders<T>.Filter.Eq("_id", id);
            var result = await _collection.FindAsync(query);
            return result.ToListAsync().Result.FirstOrDefault();
        }

        public async Task<T> Delete(T obj)
        {
            var query = Builders<T>.Filter.Eq("_id", obj._id);
            return await _collection.FindOneAndDeleteAsync(query);
        }

        public async Task<T> Update(T obj)
        {
            var query = Builders<T>.Filter.Eq("_id", obj._id);
            return await _collection.FindOneAndReplaceAsync<T>(query, obj);
        }

        public async Task<ICollection<T>> GetAll()
        {
            var query = Builders<T>.Filter.Eq("", "");
            var result = await _collection.FindAsync(query);
            return result.ToList();
        }

        public async void Insert(T obj)
        {
            await _collection.InsertOneAsync(obj);
        }
    }
}
