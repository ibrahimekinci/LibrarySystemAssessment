using System;

namespace LibrarySystem.Application.Interfaces
{
    public interface ILogService
    {
        void LogException(Exception ex);
        bool IsCriticalException(Exception ex);
        string GetUserFriendlyMessage(Exception ex);
        string GetExceptionDetails(Exception ex);
        string GetErrorTitle(Exception ex);
    }
}
