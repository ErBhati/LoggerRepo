using LoggerLibrary.Enum;
using System.Data.SqlClient;

namespace LoggerLibrary.Services.Impl
{
    internal class DbSink : ILogger
    {
        private readonly string _connectionString;

        public DbSink(string connectionString)
        {
            _connectionString = connectionString;
            EnsureLogTableExists();
        }

        public void Log(LogLevelEnum logLevel, string message)
        {
            // Example: Save log message to the database
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var commandText = "INSERT INTO [Logs] ([LogLevel], [Message], [CreatedTime]) VALUES (@LogLevel, @Message, @CreatedTime)";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@LogLevel", logLevel.ToString());
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@CreatedTime", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void EnsureLogTableExists()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var commandText = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Logs')
                    BEGIN
                        CREATE TABLE [Logs] (
                            [Id] INT IDENTITY(1,1) PRIMARY KEY,
                            [LogLevel] NVARCHAR(50) NOT NULL,
                            [Message] NVARCHAR(MAX) NOT NULL,
                            [CreatedTime] DATETIME NOT NULL
                        )
                    END";
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
