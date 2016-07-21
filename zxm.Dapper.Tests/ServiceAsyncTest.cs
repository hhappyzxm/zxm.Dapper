using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using zxm.Dapper.Tests.DatabaseFixture;
using zxm.Dapper.Tests.Entities;
using zxm.Dapper.Tests.Services;

namespace zxm.Dapper.Tests
{
    public class ServiceAsyncTest : IClassFixture<MsSqlDatabaseFixture>
    {
        private readonly DbContext _db;
        private readonly UserService _userService;

        public ServiceAsyncTest(MsSqlDatabaseFixture msSqlDatabaseFixture)
        {
            _db = msSqlDatabaseFixture.Db;
            _userService = new UserService(_db);
        }

        /// <summary>
        /// Because of test order issue, so put all methods together.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestAllMethods()
        {
            // FindAsync
            Assert.NotNull(await _userService.FindAsync(1));

            // FindAllAsync
            Assert.Equal((await _userService.FindAllAsync()).Count(), 2);

            // InsertAsync
            var insertUser = new User
            {
                Name = Guid.NewGuid().ToString()
            };

            Assert.True(await _userService.InsertAsync(insertUser));
            Assert.NotNull(await _db.SetEntity<User>().FindAsync(p => p.Name == insertUser.Name));

            // UpdateAsync
            var updateUser = new User
            {
                Id = 1,
                Name = Guid.NewGuid().ToString()
            };

            Assert.True(await _userService.UpdateAsync(updateUser));
            Assert.Equal((await _db.SetEntity<User>().FindAsync(p => p.Id == 1)).Name == updateUser.Name, true);

            // DeleteAsync
            var deleteUser = _db.SetEntity<User>().Find(p => p.Id == 1);

            Assert.True(await _userService.DeleteAsync(deleteUser));
            Assert.Null(await _db.SetEntity<User>().FindAsync(p => p.Id == 1));
        }
    }
}
