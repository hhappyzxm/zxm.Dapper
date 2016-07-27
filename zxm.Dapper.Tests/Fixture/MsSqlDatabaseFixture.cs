using Dapper;
using System;
using System.Data.SqlClient;

namespace zxm.Dapper.Tests.Fixture
{
    public class MsSqlDatabaseFixture : IDisposable
    {
        public MsSqlDatabaseFixture()
        {
            var connString = "server=smartfleetserver;database=zxm.Dapper;uid=sa;pwd=Ls1;";

            Db = new DbContext(new SqlConnection(connString));

            InitDb();
        }

        public DbContext Db { get; }

        private void InitDb()
        {
            Action<string> dropTable = name => Db.Connection.Execute($@"IF OBJECT_ID('{name}', 'U') IS NOT NULL DROP TABLE [{name}]; ");
            dropTable("Users");
           
            Db.Connection.Execute(@"CREATE TABLE Users (Id int IDENTITY(1,1) not null, Name varchar(50) not null, Deleted bit not null, PRIMARY KEY (Id))");

            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name1', 0)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name2', 0)");
            Db.Connection.Execute($"INSERT INTO [dbo].[Users]([Name],[Deleted])VALUES('Name3', 1)");
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
