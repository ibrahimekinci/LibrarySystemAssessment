using AutoMapper;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.App.Forms.Book;
using LibrarySystem.App.Forms.Dashboards;
using LibrarySystem.App.Forms.Messages;
using LibrarySystem.App.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace LibrarySystem.App.Forms.Abstracts
{
    public partial class BaseForm : Form
    {

        #region fields
        private bool _disposed;
        private static IMapper _mapper;
        protected static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = AutoMapperConfig.Mapper;
                }
                return _mapper;
            }
        }
        // Lazy initialization for thread-safety
        // Lazy initialization for thread-safety with immediate initialization
        private readonly Lazy<AuthService.AuthSoapServiceSoapClient> _authService = new Lazy<AuthService.AuthSoapServiceSoapClient>(() => new SoapApiHelper().GetAuthSoapClient());
        private readonly Lazy<BookLoanService.BookLoanSoapServiceSoapClient> _bookLoanService = new Lazy<BookLoanService.BookLoanSoapServiceSoapClient>(() => new SoapApiHelper().GetBookLoanSoapClient());
        private readonly Lazy<BookReservationService.BookReservationSoapServiceSoapClient> _bookReservationService = new Lazy<BookReservationService.BookReservationSoapServiceSoapClient>(() => new SoapApiHelper().GetBookReservationSoapClient());
        private readonly Lazy<BookService.BookSoapServiceSoapClient> _bookService = new Lazy<BookService.BookSoapServiceSoapClient>(() => new SoapApiHelper().GetBookSoapClient());
        private readonly Lazy<CategoryService.CategorySoapServiceSoapClient> _categoryService = new Lazy<CategoryService.CategorySoapServiceSoapClient>(() => new SoapApiHelper().GetCategorySoapClient());
        private readonly Lazy<LanguageService.LanguageSoapServiceSoapClient> _languageService = new Lazy<LanguageService.LanguageSoapServiceSoapClient>(() => new SoapApiHelper().GetLanguageSoapClient());
        private readonly Lazy<ReportService.ReportSoapServiceSoapClient> _reportService = new Lazy<ReportService.ReportSoapServiceSoapClient>(() => new SoapApiHelper().GetReportSoapClient());
        private readonly Lazy<TestService.TestSoapServiceSoapClient> _testService = new Lazy<TestService.TestSoapServiceSoapClient>(() => new SoapApiHelper().GetTestSoapClient());
        private readonly Lazy<UserService.UserSoapServiceSoapClient> _userService = new Lazy<UserService.UserSoapServiceSoapClient>(() => new SoapApiHelper().GetUserSoapClient());
        private readonly Lazy<AuditService.AuditSoapServiceSoapClient> _auditService = new Lazy<AuditService.AuditSoapServiceSoapClient>(() => new SoapApiHelper().GetAuditSoapClient());
        private readonly Lazy<AuthorService.AuthorSoapServiceSoapClient> _authorService = new Lazy<AuthorService.AuthorSoapServiceSoapClient>(() => new SoapApiHelper().GetAuthorSoapClient());
        private readonly Lazy<SoapApiHelper> _soapApiHelper = new Lazy<SoapApiHelper>(() => new SoapApiHelper(SessionManager.Token));
        private readonly Lazy<LogHelper> _logHelper = new Lazy<LogHelper>(() => new LogHelper());
        public AuthService.AuthSoapServiceSoapClient AuthService => _authService.Value;
        public BookLoanService.BookLoanSoapServiceSoapClient BookLoanService => _bookLoanService.Value;
        public BookReservationService.BookReservationSoapServiceSoapClient BookReservationService => _bookReservationService.Value;
        public BookService.BookSoapServiceSoapClient BookService => _bookService.Value;
        public CategoryService.CategorySoapServiceSoapClient CategoryService => _categoryService.Value;
        public LanguageService.LanguageSoapServiceSoapClient LanguageService => _languageService.Value;
        public ReportService.ReportSoapServiceSoapClient ReportService => _reportService.Value;
        public TestService.TestSoapServiceSoapClient TestService => _testService.Value;
        public UserService.UserSoapServiceSoapClient UserService => _userService.Value;
        public AuditService.AuditSoapServiceSoapClient AuditService => _auditService.Value;
        public AuthorService.AuthorSoapServiceSoapClient AuthorService => _authorService.Value;
        public SoapApiHelper SoapApiHelper => _soapApiHelper.Value;
        public LogHelper LogHelper => _logHelper.Value;

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
            (IReadOnlyList<UserLevelEnum>)new List<UserLevelEnum> { UserLevelEnum.Manager }.AsReadOnly();

        protected bool AuthorizetionCheck()
        {
            if (IsLoggedInRequired())
            {
                if (!SessionManager.IsUserLoggedIn())
                {
                    RiderectToLoginPage();
                    return false;
                }

                if (!SessionManager.IsUserAuthorized(AllowedUserLevels))
                {
                    RiderectToUnauthorizedPage();
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Dispose
        private void DisposeClient<T>(Lazy<T> client) where T : IDisposable
        {
            if (client.IsValueCreated)
            {
                try
                {
                    var serviceClient = client.Value as System.ServiceModel.ICommunicationObject;
                    if (serviceClient != null)
                    {
                        if (serviceClient.State == System.ServiceModel.CommunicationState.Faulted)
                        {
                            serviceClient.Abort();
                        }
                        else
                        {
                            serviceClient.Close();
                        }
                    }
                    client.Value.Dispose();
                }
                catch
                {
                    var serviceClient = client.Value as System.ServiceModel.ICommunicationObject;
                    serviceClient?.Abort();
                }
            }
        }
        private void ClientsDispose(object sender, FormClosingEventArgs e)
        {
            // Dispose all created objects
            if (!_disposed)
            {
                // Dispose SOAP clients
                DisposeClient(_authService);
                DisposeClient(_bookLoanService);
                DisposeClient(_bookReservationService);
                DisposeClient(_bookService);
                DisposeClient(_categoryService);
                DisposeClient(_languageService);
                DisposeClient(_reportService);
                DisposeClient(_testService);
                DisposeClient(_userService);
                DisposeClient(_auditService);
                DisposeClient(_authorService);

                // Dispose SoapApiHelper if it implements IDisposable
                if (_soapApiHelper.IsValueCreated && _soapApiHelper.Value is IDisposable disposableSoapApiHelper)
                {
                    disposableSoapApiHelper.Dispose();
                }

                // Dispose LogHelper if it implements IDisposable
                if (_logHelper.IsValueCreated && _logHelper.Value is IDisposable disposableLogHelper)
                {
                    disposableLogHelper.Dispose();
                }

                _disposed = true;
            }
        }
        #endregion

        #region Constructor 
        protected BaseForm()
        {
            this.FormClosing += ClientsDispose;

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
            if (SessionManager.IsUserLoggedIn()) this.Text += $" - {SessionManager.Username}";
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
            if (!SessionManager.IsUserLoggedIn())
            {
                RiderectToLoginPage();
                return;
            }

            if (SessionManager.IsLoggedInAsManager())
                FormManager.ShowFormOnly<BookLoanForm>(OperationType.ViewAllBookLoans);
            else if (SessionManager.IsLoggedInAsStaff())
                FormManager.ShowFormOnly<BookLoanForm>(OperationType.ViewAllBookLoans);
            else if (SessionManager.IsLoggedInAsStudent())
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
                if (ex is System.ServiceModel.FaultException soapFaultException)
                {
                    ShowError(ex.Message, "Api Error");
                }
                else if (ex is System.ServiceModel.CommunicationException soapCommunicationException)
                {
                    if (ex.Message.Contains("Server returned an invalid SOAP Fault"))
                    {
                        ShowError($"Invalid SOAP Fault Detected", "Error");
                    }
                    else
                    {
                        ShowError($"General Communication Error", "Error");
                    }
                }
                LogHelper.LogException(ex);
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
