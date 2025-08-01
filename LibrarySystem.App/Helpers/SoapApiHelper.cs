using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace LibrarySystem.App.Helpers
{
    public class SoapApiHelper
    {
        private readonly string _baseUrl;
        private readonly string _jwtToken;

        // Constructor to initialize base URL from web.config
        public SoapApiHelper(string jwtToken = null)
        {
            _baseUrl = ConfigurationManager.AppSettings["SoapApiBaseUrl"] ?? "http://librarysystem.com/Services/";
            _jwtToken = jwtToken;
        }

        // Generic method to get a configured SOAP client with optional JWT token
        public T GetSoapClient<T>(string serviceName, int timeoutSeconds = 30) where T : class
        {
            string fullUrl = $"{_baseUrl}{serviceName}.asmx";

            var binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(timeoutSeconds)
            };

            var remoteAddress = new EndpointAddress(fullUrl);

            var client = (T)Activator.CreateInstance(typeof(T), binding, remoteAddress);

            // Add JWT token to headers if provided
            if (!string.IsNullOrEmpty(_jwtToken))
            {
                using (new OperationContextScope((IContextChannel)client))
                {
                    var header = MessageHeader.CreateHeader("Authorization", "", $"Bearer {_jwtToken}");
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                }
            }

            return client;
        }

        public AuthService.AuthSoapServiceSoapClient GetAuthSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<AuthService.AuthSoapServiceSoapClient>("AuthSoapService", timeoutSeconds);
        }
        public BookLoanService.BookLoanSoapServiceSoapClient GetBookLoanSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<BookLoanService.BookLoanSoapServiceSoapClient>("BookLoanSoapService", timeoutSeconds);
        }
        public BookReservationService.BookReservationSoapServiceSoapClient GetBookReservationSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<BookReservationService.BookReservationSoapServiceSoapClient>("BookReservationSoapService", timeoutSeconds);
        }

        public BookService.BookSoapServiceSoapClient GetBookSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<BookService.BookSoapServiceSoapClient>("BookSoapService", timeoutSeconds);
        }
        public CategoryService.CategorySoapServiceSoapClient GetCategorySoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<CategoryService.CategorySoapServiceSoapClient>("CategorySoapService", timeoutSeconds);
        }
        public LanguageService.LanguageSoapServiceSoapClient GetLanguageSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<LanguageService.LanguageSoapServiceSoapClient>("LanguageSoapService", timeoutSeconds);
        }
        public ReportService.ReportSoapServiceSoapClient GetReportSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<ReportService.ReportSoapServiceSoapClient>("ReportSoapService", timeoutSeconds);
        }
        public TestService.TestSoapServiceSoapClient GetTestSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<TestService.TestSoapServiceSoapClient>("TestSoapService", timeoutSeconds);
        }
        public UserService.UserSoapServiceSoapClient GetUserSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<UserService.UserSoapServiceSoapClient>("UserSoapService", timeoutSeconds);
        }

        public AuditService.AuditSoapServiceSoapClient GetAuditSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<AuditService.AuditSoapServiceSoapClient>("AuditSoapService", timeoutSeconds);

        }
        public AuthorService.AuthorSoapServiceSoapClient GetAuthorSoapClient(int timeoutSeconds = 30)
        {
            return GetSoapClient<AuthorService.AuthorSoapServiceSoapClient>("AuthorSoapService", timeoutSeconds);
        }
    }
}
