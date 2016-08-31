using System;
using System.Data;

namespace zxm.Dapper
{
    internal class InternalRepositoryFactory : IRepositoryFactory
    {
        private static readonly Lazy<InternalRepositoryFactory> LazyRepositoryFactory = new Lazy<InternalRepositoryFactory>(()=>new InternalRepositoryFactory());

        private InternalRepositoryFactory() { }

        public static InternalRepositoryFactory Instance => LazyRepositoryFactory.Value;

        public IRepository<TEntity> CreateRepository<TEntity>(IDbConnection connection) where TEntity : class
        {
            return new Repository<TEntity>(connection);
        }
    }
}
