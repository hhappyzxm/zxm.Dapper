using System;
using System.Collections.Generic;
using System.Data;
using MicroOrm.Dapper.Repositories.DbContext;

namespace zxm.Dapper
{
    /// <summary>
    /// DbContext
    /// </summary>
    public class DbContext : DapperDbContext, IDbContext
    {
        public DbContext(IDbConnection connection) : this(connection, InternalRepositoryFactory.Instance)
        {
        }
        
        public DbContext(IDbConnection connection, IRepositoryFactory repositoryFactory):base(connection)
        {
            Repositories = new Dictionary<Type, IRepository>();
            RepositoryFactory = repositoryFactory;
        }

        public Dictionary<Type, IRepository> Repositories;

        public IRepositoryFactory RepositoryFactory;

        /// <summary>
        /// Get repository by type of entity
        /// If can't find target repository within private dictionary, auto build new repository instance with type of entity then add it to private dictionary.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            var type = typeof (TEntity);
            if (Repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>) Repositories[type];
            }
            else
            {
                var repository = RepositoryFactory.CreateRepository<TEntity>(Connection);
                Repositories.Add(type, repository);
                return repository;
            }
        }
    }
}
