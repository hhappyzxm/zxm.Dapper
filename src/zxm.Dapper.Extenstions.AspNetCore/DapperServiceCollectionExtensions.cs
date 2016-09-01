using System;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using zxm.Dapper.Context;

namespace zxm.Dapper.Extenstions.AspNetCore
{
    public static class DapperServiceCollectionExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(connectionString);
            }

            return AddDapper(services, provider => new DbContext(new SqlConnection(connectionString)));
        }

        public static IServiceCollection AddDapper(this IServiceCollection services, Func<IServiceProvider, IDbContext> dbContextBuilder)
        {
            if (dbContextBuilder == null)
            {
                throw new ArgumentNullException(nameof(dbContextBuilder));
            }
            
            services.AddScoped(dbContextBuilder);

            return services;
        }
    }
}
