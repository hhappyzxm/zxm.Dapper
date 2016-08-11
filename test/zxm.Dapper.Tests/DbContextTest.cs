using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Moq;
using Xunit;
using zxm.Dapper.Tests.Entities;
using zxm.Dapper.Tests.Repositoires;

namespace zxm.Dapper.Tests
{
    public class DbContextTest
    {
        [Fact]
        public void TestSetEntity()
        {
            var sqlConnection = new Mock<IDbConnection>();
            var db = new DbContext(sqlConnection.Object);
            
            var dbType = db.GetType();
            var repositories = (Dictionary<Type, IRepository>)dbType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)[0].GetValue(db);

            var userRepository = db.SetEntity<User>();
            Assert.Equal(userRepository is IRepository<User>, true);
            Assert.Equal(repositories.Count == 1, true);
            Assert.Equal(repositories.ContainsKey(typeof(User)), true);

            for (int i = 0; i < 10; i++)
            {
                db.SetEntity<User>();
                Assert.Equal(repositories.Count == 1, true);
                Assert.Equal(repositories.ContainsKey(typeof(User)), true);
            }
        }

        [Fact]
        public void TestSetRepository()
        {
            var sqlConnection = new Mock<IDbConnection>();
            var db = new DbContext(sqlConnection.Object);

            var dbType = db.GetType();
            var repositories = (Dictionary<Type, IRepository>)dbType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)[0].GetValue(db);

            var userCustomizeRepoistory = db.SetRepository(connection => new Mock<IUserRoleRepository>().Object);
            Assert.Equal(userCustomizeRepoistory is IUserRoleRepository, true);
            Assert.Equal(repositories.Count == 1, true);
            Assert.Equal(repositories.ContainsKey(typeof(IUserRoleRepository)), true);

            for (int i = 0; i < 10; i++)
            {
                db.SetRepository(connection => new Mock<IUserRoleRepository>().Object);
                Assert.Equal(repositories.Count == 1, true);
                Assert.Equal(repositories.ContainsKey(typeof(IUserRoleRepository)), true);
            }
        }
    }
}
