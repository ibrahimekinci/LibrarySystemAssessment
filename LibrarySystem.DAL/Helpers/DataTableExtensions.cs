using System;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Helpers
{
    public static class DataTableExtensions
    {
        public static List<TDestination> ToList<TDestination>(this DataTable table) where TDestination : new()
        {


            if (table == null)
                return null;

            var list = new List<TDestination>();
            foreach (DataRow row in table.Rows)
            {
                var entity = new TDestination();
                if (row == null)
                    continue; // Skip to next iteration if row is null

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
