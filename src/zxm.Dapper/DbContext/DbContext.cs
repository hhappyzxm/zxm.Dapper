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
        private Dictionary<Type, IRepository> Repositories { get; }

        /// <summary>
        /// Constructor of DbContext
        /// </summary>
        /// <param name="connection"></param>
        public DbContext(IDbConnection connection) : base(connection)
        {
            Repositories = new Dictionary<Type, IRepository>();
        }

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
                var repository = new Repository<TEntity>(Connection);
                Repositories.Add(type, repository);
                return repository;
            }
        }

        /// <summary>
        /// Get repository by it's own type
        /// If can't find target within private dicionary, build new repository instance through func from caller then add it to private dictionary
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TRepository SetRepository<TRepository>(Func<IDbConnection, TRepository> func) where TRepository : IRepository
        {
            var type = typeof (TRepository);
            if (Repositories.ContainsKey(type))
            {
                return (TRepository) Repositories[type];
            }
            else
            {
                var repository = func(Connection);
                Repositories.Add(type, repository);
                return repository;
            }
        }
    }
}
