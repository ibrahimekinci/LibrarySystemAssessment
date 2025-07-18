using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.Enums;

namespace LibrarySystem.Application.Interfaces
{
    public interface IAuditLogService
    {
        void Log(AuditActionType actionType, int userId, string details);
        void Log(AuditLogDto log);
    }
}
