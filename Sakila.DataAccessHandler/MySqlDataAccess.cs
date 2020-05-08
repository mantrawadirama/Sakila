using System.Data;
using MySql.Data.MySqlClient;

namespace Sakila.DataAccessHandler
{
    class MySqlDataAccess : IDatabaseHandler
    {
        private string ConnectionString { get; set; }

        public MySqlDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            var sqlConnection = (MySqlConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new MySqlCommand
            {
                CommandText = commandText,
                Connection = (MySqlConnection)connection,
                CommandType = commandType
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new MySqlDataAdapter((MySqlCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            MySqlCommand SQLcommand = (MySqlCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}
