using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Moq;
using Xunit;
using zxm.Dapper.Context;
using zxm.Dapper.Repository;
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
            
            var repositories = db.Repositories;

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
        
    }
}
