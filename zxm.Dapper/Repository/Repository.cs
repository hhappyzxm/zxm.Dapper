using System.Data;
using System.Reflection;
using MicroOrm.Dapper.Repositories;

namespace zxm.Dapper
{
    /// <summary>
    /// Repository
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Db Connection
        /// </summary>
        public IDbConnection Connection { get; }

        /// <summary>
        /// Constructor of Repository
        /// </summary>
        /// <param name="connection"></param>
        public Repository(IDbConnection connection)
        {
            Connection = connection;
        }
    }

    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : DapperRepository<TEntity>, IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Constructor of Repository
        /// </summary>
        /// <param name="connection"></param>
        public Repository(IDbConnection connection) : base(connection)
        {
        }
    }
}
