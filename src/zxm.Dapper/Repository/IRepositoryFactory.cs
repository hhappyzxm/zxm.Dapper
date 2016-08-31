using System.Data;

namespace zxm.Dapper
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> CreateRepository<TEntity>(IDbConnection connection) where TEntity : class;
    }
}
