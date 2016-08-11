using System;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace zxm.Dapper.Extenstions.AspNetCore
{
    public static class DapperServiceCollectionExtensions
    {
        public static IServiceCollection AddMailKit(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(connectionString);
            }

            return AddMailKit(services, () => new DbContext(new SqlConnection(connectionString)));
        }

        public static IServiceCollection AddMailKit(this IServiceCollection services, Func<IDbContext> dbContextBuilder)
        {
            if (dbContextBuilder == null)
            {
                throw new ArgumentNullException(nameof(dbContextBuilder));
            }
            
            services.AddSingleton(provider => dbContextBuilder());

            return services;
        }
    }
}
