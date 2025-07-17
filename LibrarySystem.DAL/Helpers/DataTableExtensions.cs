using System;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Helpers
{
    public static class DataTableExtensions
    {
        public static List<TDestination> ToList<TDestination>(this DataTable table) where TDestination : new()
        {
            var list = new List<TDestination>();

            if (table == null || table.Rows.Count == 0)
                return list;

            foreach (DataRow row in table.Rows)
            {
                var entity = new TDestination();
                if (row != null)
                {
                    list.Add(entity); // Add default instance if row is null
                    continue; // Skip to next iteration if row is null
                }

                var properties = typeof(TDestination).GetProperties();

                foreach (var property in properties)
                {
                    if (row.Table.Columns.Contains(property.Name))
                    {
                        var value = row[property.Name];
                        if (value != DBNull.Value)
                        {
                            property.SetValue(entity, value);
                        }
                    }
                }


                list.Add(entity);
            }

            return list;
        }
    }
}
