using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;

namespace LibrarySystem.Abstractions.Services
{
    public interface IAuditLogService
    {
        void Log(AuditActionType actionType, int userId = -1, string details = null);
        void Log(AuditLogDto log);
    }
}
