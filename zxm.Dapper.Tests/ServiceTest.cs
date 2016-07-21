using System;
using System.Linq;
using Xunit;
using zxm.Dapper.Tests.DatabaseFixture;
using zxm.Dapper.Tests.Entities;
using zxm.Dapper.Tests.Services;

namespace zxm.Dapper.Tests
{
    public class ServiceTest : IClassFixture<MsSqlDatabaseFixture>
    {
        private readonly DbContext _db;
        private readonly UserService _userService;

        public ServiceTest(MsSqlDatabaseFixture msSqlDatabaseFixture)
        {
            _db = msSqlDatabaseFixture.Db;
            _userService = new UserService(_db);
        }

        /// <summary>
        /// Because of test order issue, so put all methods together.
        /// </summary>
        [Fact]
        public void TestAllMethods()
        {
            // Find
            Assert.NotNull(_userService.Find(1));

            // FindAll
            Assert.Equal(_userService.FindAll().Count(), 2);

            // Insert
            var insertUser = new User
            {
                Name = Guid.NewGuid().ToString()
            };

            Assert.True(_userService.Insert(insertUser));
            Assert.NotNull(_db.SetEntity<User>().Find(p => p.Name == insertUser.Name));

            // Update
            var updateUser = new User
            {
                Id = 1,
                Name = Guid.NewGuid().ToString()
            };

            Assert.True(_userService.Update(updateUser));
            Assert.Equal(_db.SetEntity<User>().Find(p => p.Id == 1).Name == updateUser.Name, true);

            // Delete
            var deleteUser = _db.SetEntity<User>().Find(p => p.Id == 1);

            Assert.True(_userService.Delete(deleteUser));
            Assert.Null(_db.SetEntity<User>().Find(p => p.Id == 1));
        }
    }
}
