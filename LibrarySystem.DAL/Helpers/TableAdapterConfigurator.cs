using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LibrarySystem.DAL.Helpers
{
    public static class TableAdapterConfigurator
    {
        private static int _commandTimeout = 0;
        private static int commandTimeout
        {
            get
            {
                if (_commandTimeout == 0)
                {
                    _commandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"] ?? "20");
                    return _commandTimeout;

                }
                return _commandTimeout;
            }
        }
        public static void Configure(this SqlDataAdapter adapter)
        {
            string connStr = ConnectionResolver.ConnectionString;

            if (adapter.SelectCommand != null)
            {
                adapter.SelectCommand.Connection = new SqlConnection(connStr);
                adapter.SelectCommand.CommandTimeout = commandTimeout;
            }

            if (adapter.InsertCommand != null)
            {
                adapter.InsertCommand.Connection = new SqlConnection(connStr);
                adapter.InsertCommand.CommandTimeout = commandTimeout;
            }

            if (adapter.UpdateCommand != null)
            {
                adapter.UpdateCommand.Connection = new SqlConnection(connStr);
                adapter.UpdateCommand.CommandTimeout = commandTimeout;
            }

            if (adapter.DeleteCommand != null)
            {
                adapter.DeleteCommand.Connection = new SqlConnection(connStr);
                adapter.DeleteCommand.CommandTimeout = commandTimeout;
            }
        }
    }
}