using System.Data;
using zxm.Dapper.Repository;

namespace zxm.Dapper.Context
{
    /// <summary>
    /// DbContext interface
    /// </summary>
    public interface IDbContext
    {
        IDbConnection Connection { get; }

        /// <summary>
        /// Get repository by type of entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> SetEntity<TEntity>() where TEntity : class;
    }
}
