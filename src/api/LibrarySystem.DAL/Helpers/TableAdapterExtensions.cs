using System.Data.SqlClient;
using System.Reflection;

namespace LibrarySystem.DAL.Helpers
{
    public static class TableAdapterExtensions
    {
        public static void ApplyGlobalConfiguration(this object adapterObj)
        {
            if (adapterObj == null) return;
            var adapterProp = adapterObj.GetType().GetProperty("Adapter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (adapterProp != null)
            {
                var sqlAdapter = adapterProp.GetValue(adapterObj) as SqlDataAdapter;
                if (sqlAdapter != null)
                {
                    sqlAdapter.Configure();
                }
            }
        }
    }
}