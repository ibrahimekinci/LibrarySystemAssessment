using System.Data.SqlClient;

namespace LibrarySystem.DAL.Helpers
{
    public static class TableAdapterConfigurator
    {
        public static void Configure(this SqlDataAdapter adapter)
        {
            string connStr = ConnectionResolver.ConnectionString;

            if (adapter.SelectCommand != null)
            {
                adapter.SelectCommand.Connection = new SqlConnection(connStr);
                adapter.SelectCommand.CommandTimeout = 30;
            }

            if (adapter.InsertCommand != null)
            {
                adapter.InsertCommand.Connection = new SqlConnection(connStr);
                adapter.InsertCommand.CommandTimeout = 30;
            }

            if (adapter.UpdateCommand != null)
            {
                adapter.UpdateCommand.Connection = new SqlConnection(connStr);
                adapter.UpdateCommand.CommandTimeout = 30;
            }

            if (adapter.DeleteCommand != null)
            {
                adapter.DeleteCommand.Connection = new SqlConnection(connStr);
                adapter.DeleteCommand.CommandTimeout = 30;
            }
        }
    }
}