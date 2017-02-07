using Data.Domain;
using Data.Repositories.Base;
using Data.Repositories.Interfaces;
using MongoDB.Driver;

namespace Data.Repositories.Repository
{
    
    public class UsuarioRepository : MongoRepositoryBase<Usuario> , IUsuarioRepository
    {
        public UsuarioRepository(IMongoDatabase dataBase, string collection) : base(dataBase, collection)
        {
        }
    }
}
