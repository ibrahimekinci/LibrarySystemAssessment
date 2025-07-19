using System;
using System.Diagnostics;
using System.IO;
using LibrarySystem.BLL.Interfaces;

namespace LibrarySystem.BLL.Services
{
    public class LogService : ILogService
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "ErrorLog.txt");

        public void LogException(Exception ex)
        {
            try
            {
                Debug.WriteLine($"EXCEPTION: {ex}");

                if (!Directory.Exists(Path.GetDirectoryName(LogFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));

                File.AppendAllText(LogFilePath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {GetExceptionDetails(ex)}\n\n");
            }
            catch (Exception logException)
            {
                Debug.WriteLine($"EXCEPTION silently fail: {logException}");
            }
        }
        public bool IsCriticalException(Exception ex) =>
            ex is OutOfMemoryException ||
            ex is AppDomainUnloadedException ||
            ex is BadImageFormatException;

        public string GetExceptionDetails(Exception ex) =>
            $"Message: {ex.Message}\n" +
            $"Type: {ex.GetType().Name}\n" +
            $"Stack Trace:\n{ex.StackTrace}\n" +
            (ex.InnerException != null ? $"Inner Exception:\n{GetExceptionDetails(ex.InnerException)}" : "");

        public string GetUserFriendlyMessage(Exception ex)
        {
            if (ex is System.Data.Common.DbException)
            {
                return "A database error occurred. Please try again later.";
            }
            else if (ex is IOException)
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


        public string GetErrorTitle(Exception ex)
        {
            if (ex is System.Data.Common.DbException)
            {
                return "Database Error";
            }
            else if (ex is IOException)
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
