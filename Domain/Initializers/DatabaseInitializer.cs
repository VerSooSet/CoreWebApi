using System.Data.Common;
using System.Data.SqlClient;

namespace Domain.Initializers
{
    public static class DatabaseInitializer
    {
        public static string ConnectionString { get; private set; }
        public static void Init(string connString)
        {
            ConnectionString = connString;
            //FIXME
            // InitSchema();
        }

        private static void InitSchema()
        {
            using DbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            using DbCommand command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    CityId INTEGER
                );
                CREATE TABLE IF NOT EXISTS Content (
                    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    OwnerId INTEGER NOT NULL,
                    DateTimeUtc TEXT NOT NULL,
                    CONSTRAINT FK_Content_Owner FOREIGN KEY (OwnerId) REFERENCES Users (Id)
                );
                ";
            command.ExecuteNonQuery();
        }
    }
}
