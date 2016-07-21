using MicroOrm.Dapper.Repositories;

namespace zxm.Dapper
{
    /// <summary>
    /// Repository interface
    /// </summary>
    public interface IRepository
    {
    }

    /// <summary>
    /// Repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository, IDapperRepository<TEntity> 
        where TEntity : class
    {
    }
}
