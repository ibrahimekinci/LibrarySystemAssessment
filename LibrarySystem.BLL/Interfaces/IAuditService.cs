using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IAuditLogService
    {
        void Log(AuditActionType actionType, int userId = -1, string details = null);
        void Log(AuditLogDto log);
    }
}
