using LibrarySystem.Domain.Enums;
using LibrarySystem.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.UI.Forms
{
    public partial class FormBase : Form
    {
        #region Virtuals
        protected virtual bool IsLoggedInRequired() => true;
        protected virtual IReadOnlyList<UserLevelEnum> AllowedUserLevels => defaultAllowedUserLevels;
        public virtual string FormTitle { get; }
        protected virtual void LoadFormData() { }
        protected virtual void InitializeForm()
        {
            LoadFormData();
        }
        protected virtual void InitializeUIAdditional() { }

        #endregion

        #region Authorizetion

        private static readonly IReadOnlyList<UserLevelEnum> defaultAllowedUserLevels =
    new List<UserLevelEnum> { UserLevelEnum.Manager }.AsReadOnly();
        protected bool AuthorizetionCheck()
        {
            if (IsLoggedInRequired())
            {
                if (!UserManager.IsUserLoggedIn())
                {
                    RiderectToLoginPage();
                    return false;
                }
                else if (!UserManager.IsUserAuthorized(AllowedUserLevels))
                {
                    RiderectToUnauthorizedPage();
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Constructor 
        protected FormBase()
        {
            if (!AuthorizetionCheck())
                return;
            InitializeFormBase();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                if (this.MdiParent != null)
                    AppTheme.StyleMdiChildForm(this);
                InitializeForm();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormBase";
            this.ResumeLayout(false);
        }
        private FormBorderStyle _previousBorderStyle;
        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                if (this.FormBorderStyle != FormBorderStyle.None)
                {
                    _previousBorderStyle = this.FormBorderStyle;
                    this.FormBorderStyle = FormBorderStyle.None;
                }
            }
            else
            {
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    this.FormBorderStyle = _previousBorderStyle != 0 ? _previousBorderStyle : FormBorderStyle.Sizable;
                }
            }
        }
        private void InitializeFormBase()
        {
            InitializeUI();
            InitializeUIAdditional();
            InitializeExceptionHandling();
        }
        private void InitializeUI()
        {
            this.Text = string.IsNullOrWhiteSpace(FormTitle) ? "Library System" : FormTitle;
            if (UserManager.IsUserLoggedIn()) this.Text += $" - {UserManager.CurrentUser.UserName}";

            AppTheme.StyleForm(this);
            // Apply theme when form loads
            this.Load += (sender, e) => AppTheme.StyleControl(this);

            // Optional: Auto-style dynamically added controls
            this.ControlAdded += (sender, e) => AppTheme.StyleControl(e.Control);

            this.Resize += Form_Resize;


        }
        #endregion

        #region Common Functionality
        protected void RiderectToDashboard()
        {
            FormManager.ShowFormOnly<DashboardForm>();
        }
        protected void RiderectToLoginPage()
        {
            FormManager.ShowFormOnly<LoginForm>();
        }
        protected void RiderectToUnauthorizedPage()
        {
            //ShowFormOnly<UnauthorizedWarningForm>();
        }
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

        #region Exception Handling
        private void InitializeExceptionHandling()
        {
            // Set up global exception handling
            Application.ThreadException += HandleThreadException;
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                HandleException(e.Exception);
            };
        }

        protected void HandleThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        protected void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }
        protected void HandleException(Exception ex)
        {
            try
            {
                ExceptionManager.LogException(ex);

                ShowError(ExceptionManager.GetUserFriendlyMessage(ex), ExceptionManager.GetErrorTitle(ex));

                if (ExceptionManager.IsCriticalException(ex))
                {
                    MessageBox.Show("A critical error occurred. Please try again.",
                        "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception logEx)
            {
                MessageBox.Show("An internal error occurred while handling another error.",
                    "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
