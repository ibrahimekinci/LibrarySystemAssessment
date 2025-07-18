using LibrarySystem.App.Forms.Dashboards;
using LibrarySystem.App.Helpers;
using LibrarySystem.Application.Interfaces;
using LibrarySystem.Application.Services;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Abstracts
{
    public partial class BaseForm : Form
    {
        #region Services
        private IBookService _bookService;
        protected IBookService BookService
        {
            get
            {
                if (_bookService == null)
                    _bookService = new BookService();
                return _bookService;
            }
        }

        private IBarrowService _barrowService;
        protected IBarrowService BarrowService
        {
            get
            {
                if (_barrowService == null)
                    _barrowService = new BarrowService();
                return _barrowService;
            }
        }

        private IReserveService _reserveService;
        protected IReserveService ReserveService
        {
            get
            {
                if (_reserveService == null)
                    _reserveService = new ReserveService();
                return _reserveService;
            }
        }

        private IReportService _reportService;
        protected IReportService ReportService
        {
            get
            {
                if (_reportService == null)
                    _reportService = new ReportService();
                return _reportService;
            }
        }

        private IUserService _userService;
        protected IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService();
                return _userService;
            }
        }

        private IMasterDataService _masterDataService;
        protected IMasterDataService MasterDataService
        {
            get
            {
                if (_masterDataService == null)
                    _masterDataService = new MasterDataService();
                return _masterDataService;
            }
        }
        private ILogService _logService;
        protected ILogService LogService
        {
            get
            {
                if (_logService == null)
                    _logService = new LogService();
                return _logService;
            }
        }
        private IAuditLogService _auditLogService;
        protected IAuditLogService AuditLogService
        {
            get
            {
                if (_auditLogService == null)
                    _auditLogService = new AuditLogService();
                return _auditLogService;
            }
        }
        #endregion

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

        #region Authorization
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
        protected BaseForm()
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

            this.Load += (sender, e) => AppTheme.StyleControl(this);
            this.ControlAdded += (sender, e) => AppTheme.StyleControl(e.Control);
            this.Resize += Form_Resize;
        }
        #endregion

        #region Common Functionality
        protected virtual void RiderectToDashboard()
        {
            if (!UserManager.IsUserLoggedIn())
            {
                RiderectToLoginPage();
                return;
            }
            if (UserManager.CurrentUser.UserLevel == UserLevelEnum.Manager)
                FormManager.ShowFormOnly<ManagerDashboardForm>();
            else if (UserManager.CurrentUser.UserLevel == UserLevelEnum.Staff)
                FormManager.ShowFormOnly<StaffDashboardForm>();
            else if (UserManager.CurrentUser.UserLevel == UserLevelEnum.Student)
                FormManager.ShowFormOnly<StudentDashboardForm>();
        }

        protected void RiderectToLoginPage()
        {
            FormManager.ShowFormOnly<LoginForm>();
        }

        protected void RiderectToUnauthorizedPage()
        {
            // ShowFormOnly<UnauthorizedWarningForm>();
        }

        protected DialogResult ShowInformation(string message, string title = "Information")
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected DialogResult ShowConfirmation(string question, string title = "Confirm")
        {
            return MessageBox.Show(this, question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        protected void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Exception Handling

        private void InitializeExceptionHandling()
        {
            try
            {
                // Prevent duplicate event handler registrations
                System.Windows.Forms.Application.ThreadException -= HandleThreadException;
                System.Windows.Forms.Application.ThreadException += HandleThreadException;

                AppDomain.CurrentDomain.UnhandledException -= HandleUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

                TaskScheduler.UnobservedTaskException -= HandleUnobservedTaskException;
                TaskScheduler.UnobservedTaskException += HandleUnobservedTaskException;
            }
            catch (Exception ex)
            {
                LogService?.LogException(ex);
            }
        }


        private void HandleUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception);
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
                LogService.LogException(ex);
                AuditLogService.Log(AuditActionType.ApplicationException, UserManager.CurrentUser?.UID ?? 0, ex.Message);
            }
            catch (Exception logEx)
            {
                ShowError(LogService.GetUserFriendlyMessage(logEx), "An internal error occurred while handling another error." + LogService.GetErrorTitle(ex));
            }
        }
        #endregion
    }
}
