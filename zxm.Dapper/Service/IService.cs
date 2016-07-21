using System;
using System.Collections.Generic;
using System.Data;

namespace zxm.Dapper
{
    /// <summary>
    /// Service interface for sync actions
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Find entity by id except logic deleted
        /// </summary>
        /// <typeparam name="TKeyType"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        TEntity Find<TKeyType>(TKeyType id, IDbTransaction transaction = null) where TKeyType : struct;

        /// <summary>
        /// Find all entities except logic deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(IDbTransaction transaction = null);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Insert(TEntity entity, IDbTransaction transaction = null);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Update(TEntity entity, IDbTransaction transaction = null);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(TEntity entity, IDbTransaction transaction = null);
    }
}
