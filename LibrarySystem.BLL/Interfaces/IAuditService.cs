using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IAuditLogService
    {
        void Log(AuditActionType actionType, int userId, string details);
        void Log(AuditLogDto log);
    }
}
