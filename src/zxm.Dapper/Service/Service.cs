using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zxm.Dapper
{
    public class Service
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
    }
}
