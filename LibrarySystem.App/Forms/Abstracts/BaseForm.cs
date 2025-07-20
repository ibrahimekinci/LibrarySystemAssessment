using LibrarySystem.App.Forms.Book;
using LibrarySystem.App.Forms.Dashboards;
using LibrarySystem.App.Forms.Messages;
using LibrarySystem.App.Helpers;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Abstracts
{
    public partial class BaseForm : Form
    {
        #region Services
        private IAuthorService _authorService;
        protected IAuthorService AuthorService
        {
            get
            {
                if (_authorService == null)
                    _authorService = new AuthorService();
                return _authorService;
            }
        }
        private ICategoryService _categoryService;
        protected ICategoryService CategoryService
        {
            get
            {
                if (_categoryService == null)
                    _categoryService = new CategoryService();
                return _categoryService;
            }
        }
        private ILanguageService _languageService;
        protected ILanguageService LanguageService
        {
            get
            {
                if (_languageService == null)
                    _languageService = new LanguageService();
                return _languageService;
            }
        }
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

        private IBookLoanService _bookLoanService;
        protected IBookLoanService BookLoanService
        {
            get
            {
                if (_bookLoanService == null)
                    _bookLoanService = new BookLoanService();
                return _bookLoanService;
            }
        }

        private IBookReservationService _bookReservationService;
        protected IBookReservationService BookReservationService
        {
            get
            {
                if (_bookReservationService == null)
                    _bookReservationService = new BookReservationService();
                return _bookReservationService;
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
        protected virtual AuditActionType GetAuditActionForOpen()
        {
            return AuditActionType.Unknown; // Override in derived form
        }
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

                if (!UserManager.IsUserAuthorized(AllowedUserLevels))
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
            InitializeComponent(); // Required for designer
            InitializeFormBase(); // Safe UI initialization only
        }

        private void InitializeFormBase()
        {
            InitializeUI();
            InitializeUIAdditional();
        }

        private void InitializeUI()
        {
            this.Text = string.IsNullOrWhiteSpace(FormTitle) ? "Library System" : FormTitle;
            if (UserManager.IsUserLoggedIn()) this.Text += $" - {UserManager.CurrentUser.UserName}";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //if (!AuthorizetionCheck())
            //    return;

            // Apply general form styling for non-MDI forms
            if (this.MdiParent == null)
                AppTheme.StyleForm(this);
            // Apply MDI-specific styling for MDI child forms
            else
                AppTheme.StyleMdiChildForm(this);

            InitializeForm();

            this.Load += (sender, ev) => AppTheme.StyleControl(this);
            this.ControlAdded += (sender, ev) => AppTheme.StyleControl(ev.Control);
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

            if (UserManager.IsloggedInAsManager())
                FormManager.ShowFormOnly<BookLoanForm>(OperationType.ViewAllBookLoans);
            else if (UserManager.IsloggedInAsStaff())
                FormManager.ShowFormOnly<BookLoanForm>(OperationType.ViewAllBookLoans);
            else if (UserManager.IsloggedInAsStudent())
                FormManager.ShowFormOnly<StudentDashboardForm>();
        }

        protected virtual void RiderectToLoginPage()
        {
            MessageBox.Show("Please log in to continue.", "Authentication Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //LoginForm form = new LoginForm();
            //form.Show();
            FormManager.ShowFormOnly<LoginForm>();
            this.Close(); // Close the current form
        }

        protected virtual void RiderectToUnauthorizedPage()
        {
            MessageBox.Show("You do not have permission to access this page.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //UnauthorizedMessageForm unauthorizedForm = new UnauthorizedMessageForm();
            //unauthorizedForm.Show();
            FormManager.ShowFormInMdi<UnauthorizedMessageForm>();
            this.Close(); // Close the current form

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

        protected void HandleException(Exception ex)
        {
            try
            {
                LogService.LogException(ex);
                AuditLogService.Log(AuditActionType.ApplicationException, UserManager.CurrentUser?.UID ?? 0, ex.Message);
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
        #endregion
    }
}
