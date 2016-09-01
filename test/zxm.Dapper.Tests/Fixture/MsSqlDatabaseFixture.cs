using Dapper;
using System;
using System.Data.SqlClient;
using zxm.Dapper.Context;

namespace zxm.Dapper.Tests.Fixture
{
    public class MsSqlDatabaseFixture : IDisposable
    {
        public MsSqlDatabaseFixture()
        {
            //var connString = "server=192.168.0.200;database=zxm.Dapper;uid=sa;pwd=Ls1;";
            var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=zxm.Dapper;Integrated Security=True;";

            Db = new DbContext(new SqlConnection(connString));

            InitDb();
        }

        public DbContext Db { get; }

        private void InitDb()
        {
            Action<string> dropTable = name => Db.Connection.Execute($@"IF OBJECT_ID('{name}', 'U') IS NOT NULL DROP TABLE [{name}]; ");
            dropTable("Users");
            dropTable("Cars");
            dropTable("Roles");
            dropTable("Images");
            dropTable("Dishes");
            dropTable("DishImages");
            dropTable("DishOptions");

            Db.Connection.Execute(@"CREATE TABLE Users (Id int IDENTITY(1,1) not null, Name varchar(50) not null, Deleted bit not null, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Cars (Id int IDENTITY(1,1) not null, CarName varchar(50) not null, UserId int, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Roles (Id int IDENTITY(1,1) not null, Name varchar(50) not null, UserId int, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Images (Id int IDENTITY(1,1) not null, Name varchar(50) not null, UserId int, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Dishes (DishId int IDENTITY(1,1) not null, Name varchar(50) not null, PRIMARY KEY (DishId))");
            Db.Connection.Execute(@"CREATE TABLE DishImages (DishImageId int IDENTITY(1,1) not null, DishId int not null, Image varchar(50) not null, PRIMARY KEY (DishImageId))");
            Db.Connection.Execute(@"CREATE TABLE DishOptions (DishOptionId int IDENTITY(1,1) not null, DishId int not null, OptionName varchar(50) not null, PRIMARY KEY (DishOptionId))");

            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name1', 0)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name2', 0)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name3', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Cars]([CarName],[UserId])VALUES('Car1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Cars]([CarName],[UserId])VALUES('Car2', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role2', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role3', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role1', 2)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Images]([Name],[UserId])VALUES('Image1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Images]([Name],[UserId])VALUES('Image1', 2)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Images]([Name],[UserId])VALUES('Image2', 2)");

            Db.Connection.Execute($"INSERT INTO [dbo].[Dishes]([Name])VALUES('Dish1')");
            Db.Connection.Execute($"INSERT INTO [dbo].[Dishes]([Name])VALUES('Dish2')");
            Db.Connection.Execute($"INSERT INTO [dbo].[Dishes]([Name])VALUES('Dish3')");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishImages]([Image],[DishId])VALUES('DishImage1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishImages]([Image],[DishId])VALUES('DishImage2', 2)");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishImages]([Image],[DishId])VALUES('DishImage1', 3)");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishImages]([Image],[DishId])VALUES('DishImage2', 3)");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishOptions]([OptionName],[DishId])VALUES('DishOption1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishOptions]([OptionName],[DishId])VALUES('DishOption2', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[DishOptions]([OptionName],[DishId])VALUES('DishOption1', 3)");
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
