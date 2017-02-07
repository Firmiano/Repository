using System;
using Data.Domain;
using Data.Repositories.Interfaces;
using IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace RepositoryTeste.Repository
{
    [TestClass]
    public class UnitTest1
    {
        private Container _container;

        [TestInitialize()]
        public void Initialize()
        {
            _container = SimpleInjectorContainer.RegisterServices();
        }
        
        [TestMethod]
        public void InsertAsync()
        {
            var repo = _container.GetInstance<IUsuarioRepository>();

            var rd = new Random();
            
            repo.InsertAsync(new Usuario()
            {
                _id = rd.Next(1, 99999)
            }).Wait();
        }
        
        [TestMethod]
        public void Insert()
        {
            var repo = _container.GetInstance<IUsuarioRepository>();

            var rd = new Random();

            repo.Insert(new Usuario()
            {
                _id = rd.Next(1,99999)
            });
        }
        
        [TestMethod]
        public void FindAsync()
        {
            var repo = _container.GetInstance<IUsuarioRepository>();
            var result = repo.GetByIdAsync(10).Result;
            Assert.AreEqual(result._id,10);
        }
        
        [TestMethod]
        public void Find()
        {
            var repo = _container.GetInstance<IUsuarioRepository>();
            var result = repo.GetById(10);
            Assert.AreEqual(result._id, 10);
        }
    }
}
