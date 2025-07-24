using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;

public class AuditLogService : IAuditLogService
{
    private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "AuditLog.txt");
    public void Log(AuditActionType actionType, int userId = -1, string details = null)
    {
        var logDto = new AuditLogDto
        {
            ActionType = actionType,
            UserId = userId,
            Details = details
        };

        Log(logDto);
    }
    public void Log(AuditLogDto log)
    {
        try
        {
            if (!Directory.Exists(Path.GetDirectoryName(LogFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));

            string logEntry = $"[{log.ActionTime:yyyy-MM-dd HH:mm:ss}] " +
                              $"UserID: {log.UserId}, " +
                              $"Action: {log.ActionType}, Details: {log.Details}";

            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Audit logging failed: " + ex.Message);
        }
    }

    public List<AuditLogDto> GetLogs()
    {
        // optional - implement if you want to read logs from txt
        return new List<AuditLogDto>(); // empty for now
    }
}
