using System.Data;
using zxm.Dapper.Repository;

namespace zxm.Dapper
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> CreateRepository<TEntity>(IDbConnection connection) where TEntity : class;
    }
}
