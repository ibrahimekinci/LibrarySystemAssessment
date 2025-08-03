using System.Configuration;

namespace LibrarySystem.DAL.Helpers
{
    public static class ConnectionResolver
    {
        public static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = getConnectionString();
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        private static string getConnectionString()
        {
            string env = ConfigurationManager.AppSettings["Environment"] ?? "dev";
            string connNameKey = $"ConnectionName.{env}";
            string connName = ConfigurationManager.AppSettings[connNameKey];

            if (string.IsNullOrEmpty(connName))
                throw new ConfigurationErrorsException($"Connection name not defined for environment: {env}");

            var connStr = ConfigurationManager.ConnectionStrings[connName]?.ConnectionString;

            if (string.IsNullOrEmpty(connStr))
                throw new ConfigurationErrorsException($"Connection string not found for name: {connName}");

            return connStr;
        }
    }
}