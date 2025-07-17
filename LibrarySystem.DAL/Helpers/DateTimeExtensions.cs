using System;

namespace LibrarySystem.DAL.Helpers
{
    public static class DateTimeExtensions
    {
        public static string FormatForDb(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
