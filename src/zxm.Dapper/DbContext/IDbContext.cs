using System;
using System.Data;
using MicroOrm.Dapper.Repositories.DbContext;

namespace zxm.Dapper
{
    /// <summary>
    /// DbContext interface
    /// </summary>
    public interface IDbContext : IDapperDbContext
    {
        /// <summary>
        /// Get repository by type of entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> SetEntity<TEntity>() where TEntity : class;
    }
}
