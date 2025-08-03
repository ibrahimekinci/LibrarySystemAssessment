using LibrarySystem.App.Forms;
using LibrarySystem.App.Forms.Messages;
using LibrarySystem.App.Helpers;
using System;
using System.Diagnostics;
using System.Threading;

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

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            // Global UI Thread exception handler
            System.Windows.Forms.Application.ThreadException += HandleThreadException;
            // Global non-UI thread (e.g., Task) exception handler
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            System.Windows.Forms.Application.Run(new LoginForm());
        }
        private static void HandleThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowErrorForm(e.Exception);
        }
        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ShowErrorForm(ex);
            }
        }
        private static void ShowErrorForm(Exception ex)
        {
            try
            {
                var logService = new LogHelper();
                logService.LogException(ex);
                if (logService.IsCriticalException(ex))
                {
                    var errorForm = new ErrorMessageForm();
                    errorForm.ShowDialog();
                }
            }
            catch (Exception logEx)
            {
                // If logging fails, we still want to show the error form
                Debug.WriteLine($"[LOGGING EXCEPTION]: {logEx.Message}");
            }
            finally
            {
                Debug.WriteLine($"[EXCEPTION]: {ex.Message}");
            }
        }
    }
}

