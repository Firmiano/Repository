using Data.Repositories.Interfaces;
using Data.Repositories.Repository;
using MongoDB.Driver;
using SimpleInjector;

namespace IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            var client = new MongoClient("mongodb://localhost:27017/connectTimeoutMS=10000?maxIdleTimeMS=2000&maxPoolSize=600&wtimeoutMS=300000&waitQueueMultiple=10&waitQueueTimeoutMS=30000;ProviderName=MongoDB");

            container.Register(typeof(IUsuarioRepository), () => new UsuarioRepository(client.GetDatabase("DotzaGuilherme"), "Teste"), Lifestyle.Transient);

            container.Verify();
            return container;
        }
    }
}
