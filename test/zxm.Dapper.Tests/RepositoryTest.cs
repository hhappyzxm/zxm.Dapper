using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Xunit;
using zxm.Dapper;
using zxm.Dapper.SqlGenerator;
using zxm.Dapper.Tests.Entities;
using zxm.Dapper.Tests.Fixture;

namespace zxm.Dapper.Tests
{
    public class RepositoryTest : IClassFixture<MsSqlDatabaseFixture>
    {
        private readonly MsSqlDatabaseFixture _sqlDatabaseFixture;

        public RepositoryTest(MsSqlDatabaseFixture msSqlDatabaseFixture)
        {
            _sqlDatabaseFixture = msSqlDatabaseFixture;
        }

        [Fact]
        public async Task TestMultipleMappingForOneChild()
        {
            var users = (await _sqlDatabaseFixture.Db.SetEntity<User>().FindAllAsync<Car>(null, p => p.Cars)).ToList();
            Assert.Equal(users.Count, 2);
            Assert.Equal(users[0].Cars.Count, 2);
            Assert.Equal(users[0].Cars[0].CarName, "Car1");
            Assert.Equal(users[1].Cars.Count, 0);

            //var dishes = (await _sqlDatabaseFixture.Db.SetEntity<Dish>().FindAllAsync<DishImage>(null, p => p.DishImages)).ToList();
            //Assert.Equal(dishes.Count, 3);
            //Assert.Equal(dishes[0].DishImages.Count, 1);
            //Assert.Equal(dishes[1].DishImages.Count, 1);
            //Assert.Equal(dishes[2].DishImages.Count, 2);
        }

        [Fact]
        public async Task TestMultipleMappingForTwoChild()
        {
            var users = (await _sqlDatabaseFixture.Db.SetEntity<User>().FindAllAsync<Car, Role>(null, p => p.Cars, p => p.Roles)).ToList();
            Assert.Equal(users.Count, 2);
            Assert.Equal(users[0].Cars.Count, 2);
            Assert.Equal(users[0].Cars[0].CarName, "Car1");
            Assert.Equal(users[0].Roles.Count, 3);
            Assert.Equal(users[1].Cars.Count, 0);
            Assert.Equal(users[1].Roles.Count, 1);

            var dishes = (await _sqlDatabaseFixture.Db.SetEntity<Dish>().FindAllAsync<DishImage, DishOption>(null, p => p.DishImages, p=>p.DishOptions)).ToList();
            Assert.Equal(dishes.Count, 3);
            Assert.Equal(dishes[0].DishImages.Count, 1);
            Assert.Equal(dishes[0].DishOptions.Count, 2);
            Assert.Equal(dishes[0].DishOptions[0].OptionName, "DishOption1");
            Assert.Equal(dishes[1].DishImages.Count, 1);
            Assert.Equal(dishes[1].DishOptions.Count, 0);
            Assert.Equal(dishes[2].DishImages.Count, 2);
            Assert.Equal(dishes[2].DishOptions.Count, 1);
        }

        [Fact]
        public async Task TestMultipleMappingForThreeChild()
        {
            var users = (await _sqlDatabaseFixture.Db.SetEntity<User>().FindAllAsync<Car, Role, Image>(null, p => p.Cars, p => p.Roles, p=>p.Images)).ToList();
            Assert.Equal(users.Count, 2);
            Assert.Equal(users[0].Cars.Count, 2);
            Assert.Equal(users[0].Roles.Count, 3);
            Assert.Equal(users[0].Images.Count, 1);
            Assert.Equal(users[0].Cars[0].CarName, "Car1");
            Assert.Equal(users[1].Cars.Count, 0);
            Assert.Equal(users[1].Roles.Count, 1);
            Assert.Equal(users[1].Images.Count, 2);
            Assert.Equal(users[1].Images[1].Name, "Image2");
        }
    }
}
