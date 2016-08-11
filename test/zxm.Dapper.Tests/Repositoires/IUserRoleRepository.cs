using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using zxm.Dapper.Tests.Entities;

namespace zxm.Dapper.Tests.Repositoires
{
    public interface IUserRoleRepository : IRepository
    {
        User Find(int id);
    }
}
