using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
//using System.Data.OleDb;
//using System.Data.Odbc;

namespace Sakila.DataAccessHandler
{
    public class DataParameterManager
    {
        public static IDbDataParameter CreateParameter(string providerName, string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, value, dbType, direction);
                case "mysql.data.mysqlclient":
                    return CreateMySqlParameter(name, value, dbType, direction);
                //case "system.data.oleDb":
                //    break;
                //case "system.data.odbc":
                //    break;
            }

            return parameter;
        }

        public static IDbDataParameter CreateParameter(string providerName, string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, size, value, dbType, direction);
                case "mysql.data.mysqlclient":
                    return CreateMySqlParameter(name, size, value, dbType, direction);
                //case "system.data.oleDb":
                //    break;
                //case "system.data.odbc":
                //    break;
            }

            return parameter;
        }

        private static IDbDataParameter CreateSqlParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
       
        private static IDbDataParameter CreateSqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateMySqlParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new MySqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateMySqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new MySqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
    }
}
