using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zxm.Dapper.SqlGenerator;

namespace zxm.Dapper.Repository
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
    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {
        /// <summary>
        ///
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        ///
        /// </summary>
        ISqlGenerator<TEntity> SqlGenerator { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        TEntity Find(IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        TEntity Find(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        TEntity Find<TChild1>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<TEntity> FindAsync<TChild1>(Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<TEntity> FindAsync<TChild1>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<TEntity> FindAsync(IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAll(IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAll<TChild1>(Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAll<TChild1>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAllAsync(IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllAsync<TChild1>(Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllAsync<TChild1>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2>(Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, Expression<Func<TEntity, object>> tChild3, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class where TChild3 : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, Expression<Func<TEntity, object>> tChild3, IDbTransaction transaction = null) where TChild1 : class where TChild2 : class where TChild3 : class;

        /// <summary>
        ///
        /// </summary>
        bool Insert(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>>
        Task<bool> InsertAsync(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        bool Delete(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<bool> DeleteAsync(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        bool Update(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<bool> UpdateAsync(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAllBetween(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAllBetween(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAllBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        IEnumerable<TEntity> FindAllBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null);

        /// <summary>
        ///
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null); 
    }
}
