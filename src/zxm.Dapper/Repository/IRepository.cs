using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2>(Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, Expression<Func<TEntity, object>> tChild3, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class where TChild3 : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, Expression<Func<TEntity, object>> tChild3, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class where TChild3 : class ;
    }
}
