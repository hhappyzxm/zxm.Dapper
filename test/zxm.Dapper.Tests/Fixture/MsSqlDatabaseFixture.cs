using Dapper;
using System;
using System.Data.SqlClient;

namespace zxm.Dapper.Tests.Fixture
{
    public class MsSqlDatabaseFixture : IDisposable
    {
        public MsSqlDatabaseFixture()
        {
            var connString = "server=192.168.0.200;database=zxm.Dapper;uid=sa;pwd=Ls1;";

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

            Db.Connection.Execute(@"CREATE TABLE Users (Id int IDENTITY(1,1) not null, Name varchar(50) not null, Deleted bit not null, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Cars (Id int IDENTITY(1,1) not null, Name varchar(50) not null, UserId int, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Roles (Id int IDENTITY(1,1) not null, Name varchar(50) not null, UserId int, PRIMARY KEY (Id))");
            Db.Connection.Execute(@"CREATE TABLE Images (Id int IDENTITY(1,1) not null, Name varchar(50) not null, UserId int, PRIMARY KEY (Id))");

            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name1', 0)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name2', 0)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name3', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Cars]([Name],[UserId])VALUES('Car1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Cars]([Name],[UserId])VALUES('Car2', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role2', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role3', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Roles]([Name],[UserId])VALUES('Role1', 2)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Images]([Name],[UserId])VALUES('Image1', 1)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Images]([Name],[UserId])VALUES('Image1', 2)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Images]([Name],[UserId])VALUES('Image2', 2)");
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
