using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain;
using Data.Repositories.Base.Interfaces;
using MongoDB.Driver;

namespace Data.Repositories.Base
{
    public class MongoRepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : DocumentBase
    {
        private readonly IMongoCollection<T> _collection;
        
        public MongoRepositoryBase(IMongoDatabase dataBase, string collection)
        {
            _collection = dataBase.GetCollection<T>(collection);
        }

        public T GetById(int id)
        {
            var query = Builders<T>.Filter.Eq("_id", id);
            var result = _collection.Find(query);
            return result.ToListAsync().Result.FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = Builders<T>.Filter.Eq("_id", id);
            var result = await _collection.FindAsync(query);
            return result.ToListAsync().Result.FirstOrDefault();
        }

        public void Insert(T obj)
        {
            _collection.InsertOne(obj);
        }

        public async Task InsertAsync(T obj)
        {
             await _collection.InsertOneAsync(obj);
        }

        public T DeleteById(int id)
        {
            var query = Builders<T>.Filter.Eq("_id", id);
            return  _collection.FindOneAndDelete(query);
        }

        public async Task<T> DeleteByIdAsync(int id)
        {
            var query = Builders<T>.Filter.Eq("_id", id);
            return await _collection.FindOneAndDeleteAsync(query);
        }

        public T Update(T obj)
        {
            var query = Builders<T>.Filter.Eq("_id", obj._id);
            return  _collection.FindOneAndReplace<T>(query, obj);
        }

        public async Task<T> UpdatetAsync(T obj)
        {
            var query = Builders<T>.Filter.Eq("_id", obj._id);
            return await _collection.FindOneAndReplaceAsync<T>(query, obj);
        }

        public ICollection<T> GetAll()
        {
            var query = Builders<T>.Filter.Eq("", "");
            var result = _collection.Find(query);
            return result.ToList();
        }

        public async Task<ICollection<T>> GetAlltAsync()
        {
            var query = Builders<T>.Filter.Eq("", "");
            var result = await _collection.FindAsync(query);
            return result.ToList();
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
