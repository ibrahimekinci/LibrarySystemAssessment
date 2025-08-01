using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.BLL.Services;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace LibrarySystem.WebApi.Abstracts
{
    /// <summary>
    /// Summary description for BaseSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public abstract class BaseSoapService : System.Web.Services.WebService
    {
        #region Auth
        protected class TokenHeader : SoapHeader
        {
            public string Token { get; set; }
        }
        protected AuthenticatedUserDto CheckAuth(TokenHeader tokenHeader, params UserLevelEnum[] allowedRoles)
        {
            var user = JwtHelper.ValidateToken(tokenHeader?.Token);
            if (user == null)
                throw new UnauthorizedException();

            if (allowedRoles.Length > 0 && !allowedRoles.Contains(user.UserLevel))
                throw new ForbiddenException();

            HttpContext.Current.Items["AuthenticatedUser"] = user;
            return user;
        }

        protected AuthenticatedUserDto GetCurrentUser()
        {
            return HttpContext.Current.Items["AuthenticatedUser"] as AuthenticatedUserDto;
        }
        #endregion

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
        private IAuthenticationService _authenticationService;
        protected IAuthenticationService AuthenticationService
        {
            get
            {
                if (_authenticationService == null)
                    _authenticationService = new AuthenticationService();
                return _authenticationService;
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
    }
}