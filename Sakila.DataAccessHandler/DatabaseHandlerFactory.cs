using System.Configuration;

namespace Sakila.DataAccessHandler
{
    public class DatabaseHandlerFactory
    {
        private readonly ConnectionStringSettings connectionStringSettings;

        public DatabaseHandlerFactory(string connectionStringName)
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }

        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;

            switch (connectionStringSettings.ProviderName.ToLower())
            {
                case "system.data.sqlclient":
                    database = new SqlDataAccess(connectionStringSettings.ConnectionString);
                        break;
                case "mysql.data.mysqlclient":
                        database = new MySqlDataAccess(connectionStringSettings.ConnectionString);
                        break;
                //case "system.data.oleDb":
                //        database = new OledbDataAccess(connectionStringSettings.ConnectionString);
                //        break;
                //case "system.data.odbc":
                //        database = new OdbcDataAccess(connectionStringSettings.ConnectionString);
                //        break;
            }

            return database;
        }

        public string GetProviderName()
        {
            return connectionStringSettings.ProviderName;
        }
    }
}
