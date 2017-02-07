using Data.Attributes;
using Data.Domain;
using Data.Repository.Base;

namespace Data.Repository
{
    [DataBase("Teste")]
    [Collection("colecao")]
    public class UsuarioRepository : MongoRepositoryBase<Usuario>
    {
    }
}
