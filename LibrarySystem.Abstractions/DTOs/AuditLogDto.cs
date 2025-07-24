using LibrarySystem.Domain.Enums;
using System;

namespace LibrarySystem.Abstractions.DTOs
{
    public class AuditLogDto
    {
        public int? UserId { get; set; }
        public AuditActionType ActionType { get; set; }
        public DateTime ActionTime { get; set; } = DateTime.Now;
        public string Details { get; set; }
    }

}
