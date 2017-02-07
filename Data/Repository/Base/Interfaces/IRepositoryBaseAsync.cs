
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Base.Interfaces
{
    public interface IRepositoryBaseAsync<T> where T : class
    {
        Task<T> GetById(string id);
        void Insert(T obj);
        Task<T> Delete(T obj);
        Task<T> Update(T obj);
        Task<ICollection<T>> GetAll();
    }
}
