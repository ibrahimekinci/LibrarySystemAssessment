using LibrarySystem.App.Forms;
using System;
using System.Windows.Forms;

namespace LibrarySystem.App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var auditLogService = new AuditLogService();
            auditLogService.Log(Domain.Enums.AuditActionType.ApplicationStarted, 0, "LibrarySystem.App.Program.Main");
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginForm());
            auditLogService.Log(Domain.Enums.AuditActionType.ApplicationEnded, 0, "LibrarySystem.App.Program.Main");
        }
    }
}
