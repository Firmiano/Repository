
using System.Collections.Generic;

namespace Data.Repository.Base.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        T Insert(T obj);
        bool Delete(T obj);
        bool Update(T obj);
        ICollection<T> GetAll();

    }
}
