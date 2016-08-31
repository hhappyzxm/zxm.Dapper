using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Linq;
using Dapper;
using zxm.Dapper.SqlGenerator;
using zxm.Dapper.Extensions;

namespace zxm.Dapper
{
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

        #region Find

        private async Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(SqlQuery sqlQuery, Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, Expression<Func<TEntity, object>> tChild3, IDbTransaction transaction = null)
        {
            var type = typeof(TEntity);
            var propertyName1 = ExpressionHelper.GetPropertyName(tChild1);
            var propertyName2 = ExpressionHelper.GetPropertyName(tChild2);

            IEnumerable<TEntity> result = null;
            var tj1Property = type.GetProperty(propertyName1);
            if (tj1Property.PropertyType.IsGenericType())
            {
                var lookup = new Dictionary<object, TEntity>();

                var keyPropertyMeta = SqlGenerator.KeySqlProperties.FirstOrDefault();
                if (keyPropertyMeta == null)
                    throw new Exception("key not found");

                var keyProperty = keyPropertyMeta.PropertyInfo;

                await Connection.QueryAsync<TEntity, TChild1, TEntity>(sqlQuery.Sql, (entity, j1) =>
                {
                    var key = keyProperty.GetValue(entity);

                    TEntity en;
                    if (!lookup.TryGetValue(key, out en))
                    {
                        lookup.Add(key, en = entity);
                    }

                    var list = (List<TChild1>)tj1Property.GetValue(en) ?? new List<TChild1>();
                    if (j1 != null)
                        list.Add(j1);

                    tj1Property.SetValue(en, list);

                    return en;
                }, sqlQuery.Param, transaction);

                result = lookup.Values;
            }
            else
            {
                result = await Connection.QueryAsync<TEntity, TChild1, TEntity>(sqlQuery.Sql, (entity, j1) =>
                {
                    type.GetProperty(propertyName1).SetValue(entity, j1);
                    return entity;
                }, sqlQuery.Param, transaction);
            }

            return result;
        }

        #endregion
    }
}
