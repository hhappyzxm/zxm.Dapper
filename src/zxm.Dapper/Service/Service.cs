using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace zxm.Dapper
{
    /// <summary>
    /// Service Basic
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Service<TEntity> : IService<TEntity>, IServiceAsync<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// DbContext
        /// </summary>
        public IDbContext Db { get; }

        /// <summary>
        /// Constructor of Service
        /// </summary>
        /// <param name="dbContext"></param>
        public Service(IDbContext dbContext)
        {
            Db = dbContext;
        }

        #region Sync

        /// <summary>
        /// Find entity by id except logic deleted
        /// </summary>
        /// <typeparam name="TKeyType"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TEntity Find<TKeyType>(TKeyType id, IDbTransaction transaction = null)
            where TKeyType : struct
        {
            var sqlGenerator = Db.SetEntity<TEntity>().SqlGenerator;
            
            var sql =
                $"SELECT * FROM {sqlGenerator.TableName} WHERE {sqlGenerator.TableName}.{sqlGenerator.KeySqlProperties[0].ColumnName} = {id}";

            return Db.Connection.QuerySingleOrDefault<TEntity>(sql);
        }

        /// <summary>
        /// Find all entities except logic deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(IDbTransaction transaction = null)
        {
            return Db.SetEntity<TEntity>().FindAll(transaction);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Insert(TEntity entity, IDbTransaction transaction = null)
        {
            return Db.SetEntity<TEntity>().Insert(entity, transaction);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(TEntity entity, IDbTransaction transaction = null)
        {
            return Db.SetEntity<TEntity>().Update(entity, transaction);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity, IDbTransaction transaction = null)
        {
            return Db.SetEntity<TEntity>().Delete(entity, transaction);
        }

        #endregion

        #region Async

        /// <summary>
        /// Async find entity by id except logic deleted
        /// </summary>
        /// <typeparam name="TKeyType"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync<TKeyType>(TKeyType id, IDbTransaction transaction = null) where TKeyType : struct
        {
            var sqlGenerator = Db.SetEntity<TEntity>().SqlGenerator;

            var sql =
                $"SELECT * FROM {sqlGenerator.TableName} WHERE {sqlGenerator.TableName}.{sqlGenerator.KeySqlProperties[0].ColumnName} = {id}";

            return await Db.Connection.QuerySingleOrDefaultAsync<TEntity>(sql);
        }

        /// <summary>
        /// Async find all entities except logic deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync(IDbTransaction transaction = null)
        {
            return await Db.SetEntity<TEntity>().FindAllAsync(transaction);
        }

        /// <summary>
        /// Async insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(TEntity entity, IDbTransaction transaction = null)
        {
            return await Db.SetEntity<TEntity>().InsertAsync(entity, transaction);
        }

        /// <summary>
        /// Async update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            return await Db.SetEntity<TEntity>().UpdateAsync(entity, transaction);
        }

        /// <summary>
        /// Async Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(TEntity entity, IDbTransaction transaction = null)
        {
            return await Db.SetEntity<TEntity>().DeleteAsync(entity, transaction);
        }

        #endregion
    }
}
