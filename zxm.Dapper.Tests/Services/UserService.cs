using zxm.Dapper.Tests.Entities;

namespace zxm.Dapper.Tests.Services
{
    public class UserService : Service<User>
    {
        public UserService(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
