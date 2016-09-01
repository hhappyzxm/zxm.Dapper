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

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2>(
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2, 
            IDbTransaction transaction = null)
            where TChild1 : class
            where TChild2 : class
        {
            return FindAllAsync<TChild1, TChild2>(null, tChild1, tChild2, transaction);
        }


        public virtual async Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, Expression<Func<TEntity, object>> tChild2, IDbTransaction transaction = null)
            where TChild1 : class
            where TChild2 : class
        {
            var sqlQuery = SqlGenerator.GetSelectAll(predicate, tChild1, tChild2);

            var type = typeof(TEntity);
            var propertyName1 = ExpressionHelper.GetPropertyName(tChild1);
            var propertyName2 = ExpressionHelper.GetPropertyName(tChild2);
            
            var tj1Property = type.GetProperty(propertyName1);
            var tj2Property = type.GetProperty(propertyName2);

            var lookup = new Dictionary<object, TEntity>();

            var keyPropertyMeta = SqlGenerator.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta == null)
                throw new Exception("key not found");

            var sqlGenerator1 = new SqlGenerator<TChild1>();
            var keyPropertyMeta1 = sqlGenerator1.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta1 == null)
                throw new Exception("key not found");

            var sqlGenerator2 = new SqlGenerator<TChild2>();
            var keyPropertyMeta2 = sqlGenerator2.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta2 == null)
                throw new Exception("key not found");

            var keyProperty = keyPropertyMeta.PropertyInfo;
            var keyProperty1 = keyPropertyMeta1.PropertyInfo;
            var keyProperty2 = keyPropertyMeta2.PropertyInfo;

            await Connection.QueryAsync<TEntity, TChild1, TChild2, TEntity>(sqlQuery.Sql, (entity, j1, j2) =>
            {
                var key = keyProperty.GetValue(entity);

                TEntity en;
                if (!lookup.TryGetValue(key, out en))
                {
                    lookup.Add(key, en = entity);
                }

                if (tj1Property.PropertyType.IsGenericType())
                {
                    var list = (List<TChild1>)tj1Property.GetValue(en) ?? new List<TChild1>();
                    if (j1 != null)
                    {
                        var key1 = keyProperty1.GetValue(j1);
                        bool exist = false;
                        foreach (var item in list)
                        {
                            var tmpKey = keyProperty1.GetValue(item);
                            if (tmpKey.Equals(key1))
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                        {
                            list.Add(j1);
                        }
                    }

                    tj1Property.SetValue(en, list);
                }
                else
                {
                    type.GetProperty(propertyName1).SetValue(en, j1);
                }

                if (tj2Property.PropertyType.IsGenericType())
                {
                    var list = (List<TChild2>)tj2Property.GetValue(en) ?? new List<TChild2>();
                    if (j2 != null)
                    {
                        var key2 = keyProperty2.GetValue(j2);
                        bool exist = false;
                        foreach (var item in list)
                        {
                            var tmpKey = keyProperty2.GetValue(item);
                            if (tmpKey.Equals(key2))
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                        {
                            list.Add(j2);
                        }
                    }

                    tj2Property.SetValue(en, list);
                }
                else
                {
                    type.GetProperty(propertyName2).SetValue(en, j2);
                }

                return en;
            }, sqlQuery.Param, transaction);

            return lookup.Values;
        }

        public Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null)
            where TChild1 : class
            where TChild2 : class
            where TChild3 : class
        {
            return FindAllAsync<TChild1, TChild2, TChild3>(null, tChild1, tChild2, tChild3, transaction);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync<TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1, 
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3, 
            IDbTransaction transaction = null) 
            where TChild1 : class
            where TChild2 : class 
            where TChild3 : class
        {
            var sqlQuery = SqlGenerator.GetSelectAll(predicate, tChild1, tChild2, tChild3);

            var type = typeof(TEntity);
            var propertyName1 = ExpressionHelper.GetPropertyName(tChild1);
            var propertyName2 = ExpressionHelper.GetPropertyName(tChild2);
            var propertyName3 = ExpressionHelper.GetPropertyName(tChild3);
            
            var tj1Property = type.GetProperty(propertyName1);
            var tj2Property = type.GetProperty(propertyName2);
            var tj3Property = type.GetProperty(propertyName3);

            var lookup = new Dictionary<object, TEntity>();

            var keyPropertyMeta = SqlGenerator.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta == null)
                throw new Exception("key not found");

            var sqlGenerator1 = new SqlGenerator<TChild1>();
            var keyPropertyMeta1 = sqlGenerator1.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta1 == null)
                throw new Exception("key not found");

            var sqlGenerator2 = new SqlGenerator<TChild2>();
            var keyPropertyMeta2 = sqlGenerator2.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta2 == null)
                throw new Exception("key not found");

            var sqlGenerator3 = new SqlGenerator<TChild3>();
            var keyPropertyMeta3 = sqlGenerator3.KeySqlProperties.FirstOrDefault();
            if (keyPropertyMeta3 == null)
                throw new Exception("key not found");

            var keyProperty = keyPropertyMeta.PropertyInfo;
            var keyProperty1 = keyPropertyMeta1.PropertyInfo;
            var keyProperty2 = keyPropertyMeta2.PropertyInfo;
            var keyProperty3 = keyPropertyMeta3.PropertyInfo;

            await Connection.QueryAsync<TEntity, TChild1, TChild2, TChild3, TEntity>(sqlQuery.Sql, (entity, j1, j2, j3) =>
            {
                var key = keyProperty.GetValue(entity);

                TEntity en;
                if (!lookup.TryGetValue(key, out en))
                {
                    lookup.Add(key, en = entity);
                }

                if (tj1Property.PropertyType.IsGenericType())
                {
                    var list = (List<TChild1>)tj1Property.GetValue(en) ?? new List<TChild1>();
                    if (j1 != null)
                    {
                        var key1 = keyProperty1.GetValue(j1);
                        bool exist = false;
                        foreach (var item in list)
                        {
                            var tmpKey = keyProperty1.GetValue(item);
                            if (tmpKey.Equals(key1))
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                        {
                            list.Add(j1);
                        }
                    }

                    tj1Property.SetValue(en, list);
                }
                else
                {
                    type.GetProperty(propertyName1).SetValue(en, j1);
                }

                if (tj2Property.PropertyType.IsGenericType())
                {
                    var list = (List<TChild2>)tj2Property.GetValue(en) ?? new List<TChild2>();
                    if (j2 != null)
                    {
                        var key2 = keyProperty2.GetValue(j2);
                        bool exist = false;
                        foreach (var item in list)
                        {
                            var tmpKey = keyProperty2.GetValue(item);
                            if (tmpKey.Equals(key2))
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                        {
                            list.Add(j2);
                        }
                    }

                    tj2Property.SetValue(en, list);
                }
                else
                {
                    type.GetProperty(propertyName2).SetValue(en, j2);
                }

                if (tj3Property.PropertyType.IsGenericType())
                {
                    var list = (List<TChild3>)tj3Property.GetValue(en) ?? new List<TChild3>();
                    if (j3 != null)
                    {
                        var key3 = keyProperty3.GetValue(j3);
                        bool exist = false;
                        foreach (var item in list)
                        {
                            var tmpKey = keyProperty3.GetValue(item);
                            if (tmpKey.Equals(key3))
                            {
                                exist = true;
                                break;
                            }
                        }

                        if (!exist)
                        {
                            list.Add(j3);
                        }
                    }

                    tj3Property.SetValue(en, list);
                }
                else
                {
                    type.GetProperty(propertyName3).SetValue(en, j3);
                }

                return en;
            }, sqlQuery.Param, transaction);

            return lookup.Values;
        }

        #endregion
    }
}
