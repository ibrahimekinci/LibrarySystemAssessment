using LibrarySystem.BLL.DTOs;
using LibrarySystem.UI.Forms;
using LibrarySystem.UI.Styles;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.UI.Abstracts
{
    public partial class FormBase : Form
    {
        #region Common Properties

        /// <summary>
        /// Currently logged in user information
        /// </summary>
        /// 
        public void SetCurentUser(UserViewDto currentUser)
        {
            CurrentUser = currentUser;
        }
        protected static UserViewDto CurrentUser { get; set; }

        /// <summary>
        /// Indicates if the form has unsaved changes
        /// </summary>
        public bool IsDirty { get; protected set; }

        /// <summary>
        /// Form display name for titles and logging
        /// </summary>
        public virtual string FormTitle { get; }

        #endregion

        #region Constructor & Initialization

        protected FormBase()
        {
            // Wire up global exception handlers
            Application.ThreadException += HandleThreadException;
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            // Modern form styling
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = SystemColors.Window;
            this.ForeColor = SystemColors.WindowText;
            this.MinimumSize = new Size(800, 600);
            //this.Icon = Properties.Resources.AppIcon; // Your application icon
            // Apply theme when form loads
            this.Load += (sender, e) => AppTheme.StyleControl(this);

            // Optional: Auto-style dynamically added controls
            this.ControlAdded += (sender, e) => AppTheme.StyleControl(e.Control);
        }
        protected FormBase(UserViewDto user)
        {
            SetCurentUser(user);
            // Modern form styling
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = SystemColors.Window;
            this.ForeColor = SystemColors.WindowText;
            this.MinimumSize = new Size(800, 600);
            //this.Icon = Properties.Resources.AppIcon; // Your application icon
        }
        /// <summary>
        /// Initialize form with default styling and data
        /// </summary>
        protected virtual void InitializeForm()
        {
            LoadFormData();
            SetupAccessibility();
        }

        /// <summary>
        /// Load form-specific data (abstract - must be implemented)
        /// </summary>
        protected virtual void LoadFormData() { }

        #endregion



        /// <summary>
        /// Setup accessibility features
        /// </summary>
        protected virtual void SetupAccessibility()
        {
            this.AccessibleName = FormTitle;
            this.AccessibleDescription = $"Form for {FormTitle} operations";
        }


        #region Common Functionality

        /// <summary>
        /// Show informational message with modern styling
        /// </summary>
        protected DialogResult ShowInformation(string message, string title = "Information")
        {
            return MessageBox.Show(this, message, title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show confirmation dialog with modern styling
        /// </summary>
        protected DialogResult ShowConfirmation(string question, string title = "Confirm")
        {
            return MessageBox.Show(this, question, title,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
        }

        /// <summary>
        /// Show error message with modern styling
        /// </summary>
        protected void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(this, message, title,
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
        }

        #endregion

        #region Form Management

        /// <summary>
        /// Open form as singleton instance
        /// </summary>
        public static void ShowForm<T>() where T : FormBase, new()
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Normal;
                return;
            }

            var form = (T)Activator.CreateInstance(typeof(T), CurrentUser);
            form.Show();
        }
        #endregion

        #region Event Handlers

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                InitializeForm();
                // Set form title with user context
                this.Text = $"{FormTitle} - {CurrentUser?.UserName}";
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (IsDirty && ShowConfirmation("You have unsaved changes. Close anyway?") != DialogResult.Yes)
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        #endregion
        protected void RiderectToHomePage()
        {
            var form = new MenuOutlineForm(CurrentUser);
            form.Show();
            Hide();
        }

        #region Exceptions

        private readonly string _logFilePath = Path.Combine(
            Application.StartupPath,
            "ErrorLog.txt");

        #region Exception Handling Methods

        private void HandleThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        protected void HandleException(Exception ex)
        {
            try
            {
                LogException(ex);
               ShowError("Opps! There is an exception. Please try again");

                if (IsCriticalException(ex))
                {
                    Application.Exit();
                }
            }
            catch
            {
                // Last resort if error handling fails
                MessageBox.Show("A critical error occurred. The application will now close.",
                    "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void LogException(Exception ex)
        {
            try
            {
                File.AppendAllText(_logFilePath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {GetExceptionDetails(ex)}\n\n");

                Debug.WriteLine($"EXCEPTION: {ex}");
            }
            catch
            {
                // Silently fail if logging fails
            }
        }

        private string GetExceptionDetails(Exception ex)
        {
            return $"Message: {ex.Message}\n" +
                   $"Type: {ex.GetType().Name}\n" +
                   $"Stack Trace:\n{ex.StackTrace}\n" +
                   (ex.InnerException != null ?
                       $"Inner Exception:\n{GetExceptionDetails(ex.InnerException)}" : "");
        }

       
        private bool IsCriticalException(Exception ex)
        {
            return ex is OutOfMemoryException ||
                   ex is AppDomainUnloadedException ||
                   ex is BadImageFormatException;
        }

        #endregion


        #endregion
    }
}
