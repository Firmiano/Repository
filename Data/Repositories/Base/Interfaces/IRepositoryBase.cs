using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Base.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Insert(T obj);
        Task InsertAsync(T obj);
        T DeleteById(int id);
        Task<T> DeleteByIdAsync(int id);
        T Update(T obj);
        Task<T> UpdatetAsync(T obj);
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAlltAsync();

    }
}
