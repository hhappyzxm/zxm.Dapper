using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace zxm.Dapper
{
    /// <summary>
    /// Service interface for async actions
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IServiceAsync<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Async find entity by id except logic deleted
        /// </summary>
        /// <typeparam name="TKeyType"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync<TKeyType>(TKeyType id, IDbTransaction transaction = null) where TKeyType : struct;

        /// <summary>
        /// Async find all entities except logic deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAllAsync(IDbTransaction transaction = null);

        /// <summary>
        /// Async insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(TEntity entity, IDbTransaction transaction = null);

        /// <summary>
        /// Async update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, IDbTransaction transaction = null);

        /// <summary>
        /// Async delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity, IDbTransaction transaction = null);
    }
}
