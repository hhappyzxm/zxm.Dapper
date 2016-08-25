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
    public class Service<TEntity> : Service, IService<TEntity>, IServiceAsync<TEntity>
        where TEntity : class
    {
        public Service(IDbContext dbContext) : base(dbContext)
        {
        }

        protected IRepository<TEntity> Repository => Db.SetEntity<TEntity>();

        #region Sync

        /// <summary>
        /// Find entity by id except logic deleted
        /// </summary>
        /// <typeparam name="TKeyType"></typeparam>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual TEntity Find<TKeyType>(TKeyType id, IDbTransaction transaction = null)
            where TKeyType : struct
        {
            var sqlGenerator = Repository.SqlGenerator;
            
            var sql =
                $"SELECT * FROM {sqlGenerator.TableName} WHERE {sqlGenerator.TableName}.{sqlGenerator.KeySqlProperties[0].ColumnName} = {id}";

            return Db.Connection.QuerySingleOrDefault<TEntity>(sql);
        }

        /// <summary>
        /// Find all entities except logic deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> FindAll(IDbTransaction transaction = null)
        {
            return Repository.FindAll(transaction);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual bool Insert(TEntity entity, IDbTransaction transaction = null)
        {
            return Repository.Insert(entity, transaction);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual bool Update(TEntity entity, IDbTransaction transaction = null)
        {
            return Repository.Update(entity, transaction);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual bool Delete(TEntity entity, IDbTransaction transaction = null)
        {
            return Repository.Delete(entity, transaction);
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
        public virtual async Task<TEntity> FindAsync<TKeyType>(TKeyType id, IDbTransaction transaction = null) where TKeyType : struct
        {
            var sqlGenerator = Repository.SqlGenerator;

            var sql =
                $"SELECT * FROM {sqlGenerator.TableName} WHERE {sqlGenerator.TableName}.{sqlGenerator.KeySqlProperties[0].ColumnName} = {id}";

            return await Db.Connection.QuerySingleOrDefaultAsync<TEntity>(sql);
        }

        /// <summary>
        /// Async find all entities except logic deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(IDbTransaction transaction = null)
        {
            return await Repository.FindAllAsync(transaction);
        }

        /// <summary>
        /// Async insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual async Task<bool> InsertAsync(TEntity entity, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(entity, transaction);
        }

        /// <summary>
        /// Async update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync(entity, transaction);
        }

        /// <summary>
        /// Async Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(TEntity entity, IDbTransaction transaction = null)
        {
            return await Repository.DeleteAsync(entity, transaction);
        }

        #endregion
    }
}
