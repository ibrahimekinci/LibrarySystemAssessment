using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace LibrarySystem.App.Helpers
{
    public class SoapApiHelper
    {
        private static string _baseUrl;

        private static string baseUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_baseUrl))
                {
                    _baseUrl = ConfigurationManager.AppSettings["SoapApiBaseUrl"];
                    return _baseUrl;

                }
                return _baseUrl;
            }
        }
        private static int _clientTimeout = 0;
        private static int clientTimeout
        {
            get
            {
                if (_clientTimeout == 0)
                {
                    _clientTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SoapApiClientTimeOut"] ?? "20");
                    return _clientTimeout;

                }
                return _clientTimeout;
            }
        }
        public static T GetSoapClient<T>(string serviceName) where T : class
        {
            string fullUrl = $"{baseUrl}{serviceName}.asmx";

            var binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(clientTimeout),
            };

            var remoteAddress = new EndpointAddress(fullUrl);

            var client = (T)Activator.CreateInstance(typeof(T), binding, remoteAddress);

            return client;
        }

        public static AuthService.AuthSoapServiceSoapClient GetAuthSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<AuthService.AuthSoapServiceSoapClient>("AuthSoapService");

            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;

        }
        public static BookLoanService.BookLoanSoapServiceSoapClient GetBookLoanSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<BookLoanService.BookLoanSoapServiceSoapClient>("BookLoanSoapService");

            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;
            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static BookReservationService.BookReservationSoapServiceSoapClient GetBookReservationSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<BookReservationService.BookReservationSoapServiceSoapClient>("BookReservationSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }

        public static BookService.BookSoapServiceSoapClient GetBookSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<BookService.BookSoapServiceSoapClient>("BookSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static CategoryService.CategorySoapServiceSoapClient GetCategorySoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<CategoryService.CategorySoapServiceSoapClient>("CategorySoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static LanguageService.LanguageSoapServiceSoapClient GetLanguageSoapClient(string jwtToken = "", int timeoutSeconds = 30)
        {
            var client = GetSoapClient<LanguageService.LanguageSoapServiceSoapClient>("LanguageSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static ReportService.ReportSoapServiceSoapClient GetReportSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<ReportService.ReportSoapServiceSoapClient>("ReportSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static TestService.TestSoapServiceSoapClient GetTestSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<TestService.TestSoapServiceSoapClient>("TestSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static UserService.UserSoapServiceSoapClient GetUserSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<UserService.UserSoapServiceSoapClient>("UserSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }

        public static AuditService.AuditSoapServiceSoapClient GetAuditSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<AuditService.AuditSoapServiceSoapClient>("AuditSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
        public static AuthorService.AuthorSoapServiceSoapClient GetAuthorSoapClient(string jwtToken = "")
        {
            var client = GetSoapClient<AuthorService.AuthorSoapServiceSoapClient>("AuthorSoapService");
            //Auth Header
            if (string.IsNullOrEmpty(jwtToken))
                jwtToken = SessionManager.Token;

            if (string.IsNullOrEmpty(jwtToken))
                return client;

            var eab = new EndpointAddressBuilder(client.Endpoint.Address);
            eab.Headers.Add(
                  AddressHeader.CreateAddressHeader("Authorization",  // Header Name
                                                     string.Empty,           // Namespace
                                                     $"Bearer {jwtToken}"));  // Header Value
            client.Endpoint.Address = eab.ToEndpointAddress();
            return client;
        }
    }
}
