using System;

namespace LibrarySystem.Abstractions.Services
{
    public interface ILogService
    {
        void LogException(Exception ex);
        void LogInformation(string type, string content);
        bool IsCriticalException(Exception ex);
        string GetUserFriendlyMessage(Exception ex);
        string GetExceptionDetails(Exception ex);
        string GetErrorTitle(Exception ex);
    }
}
