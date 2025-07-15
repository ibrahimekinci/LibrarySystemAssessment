using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LibrarySystem.UI.Helpers
{
    public class ExceptionManager
    {
        private static readonly string _logDirectory = Path.Combine(Application.StartupPath, "logs");
        private static readonly string _logFilePath = Path.Combine(_logDirectory, "ErrorLog.txt");

        public static void LogException(Exception ex)
        {
            try
            {
                Debug.WriteLine($"EXCEPTION: {ex}");

                if (!Directory.Exists(_logDirectory))
                    Directory.CreateDirectory(_logDirectory);

                File.AppendAllText(_logFilePath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {GetExceptionDetails(ex)}\n\n");
            }
            catch (Exception logException)
            {
                Debug.WriteLine($"EXCEPTION silently fail: {logException}");
                // silently fail
            }
        }

        public static bool IsCriticalException(Exception ex)
        {
            return ex is OutOfMemoryException ||
                   ex is AppDomainUnloadedException ||
                   ex is BadImageFormatException;
        }

        public static string GetExceptionDetails(Exception ex)
        {
            return $"Message: {ex.Message}\n" +
                   $"Type: {ex.GetType().Name}\n" +
                   $"Stack Trace:\n{ex.StackTrace}\n" +
                   (ex.InnerException != null ?
                       $"Inner Exception:\n{GetExceptionDetails(ex.InnerException)}" : "");
        }



        public static string GetUserFriendlyMessage(Exception ex)
        {
            if (ex is System.Data.Common.DbException)
            {
                return "A database error occurred. Please try again later.";
            }
            else if (ex is System.IO.IOException)
            {
                return "A file access error occurred. Check your permissions.";
            }
            else if (ex is TimeoutException)
            {
                return "The operation timed out. Please check your connection.";
            }
            else if (ex is UnauthorizedAccessException)
            {
                return "You don't have permission to perform this action.";
            }
            else
            {
                return "An unexpected error occurred. Our team has been notified. Please try again.";
            }
        }

        public static string GetErrorTitle(Exception ex)
        {
            if (ex is System.Data.Common.DbException)
            {
                return "Database Error";
            }
            else if (ex is System.IO.IOException)
            {
                return "File Error";
            }
            else
            {
                return "Error";
            }
        }
    }
}
