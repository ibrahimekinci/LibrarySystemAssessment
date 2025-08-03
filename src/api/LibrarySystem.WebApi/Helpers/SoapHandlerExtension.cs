using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.BLL.Services;
using LibrarySystem.WebApi.Services;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml;

namespace LibrarySystem.WebApi.Helpers
{
    // SoapExtension to intercept and handle SOAP message processing, ensuring exceptions are returned as SoapServiceResult<T>.
    public class SoapHandlerExtension : SoapExtension
    {
        // Stores the current SOAP message being processed.
        private SoapMessage _message;

        // Required by SoapExtension; returns null as no initializer is needed for the service type.
        public override object GetInitializer(Type serviceType) => null;

        // Required by SoapExtension; returns null as no initializer is needed for the method.
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) => null;

        // Required by SoapExtension; no initialization logic needed.
        public override void Initialize(object initializer) { }

        // Processes the SOAP message at different stages of serialization/deserialization.
        public override void ProcessMessage(SoapMessage message)
        {
            _message = message;

            // Handle different stages of SOAP message processing.
            if (message.Stage == SoapMessageStage.BeforeDeserialize)
            {
                // Handle the message before deserialization.

            }
            else if (message.Stage == SoapMessageStage.AfterDeserialize)
            {
                HandleAuth(message);

                // Handle the message after deserialization, typically to check for exceptions or authentication.
            }
            else if (message.Stage == SoapMessageStage.BeforeSerialize)
            {
                // Handle the message before serialization.
                if (message.Exception != null)
                {
                    HandleException(message);
                }

            }
            else if (message.Stage == SoapMessageStage.AfterSerialize)
            {
                // Handle the message after serialization.
            }
        }

        #region Auth
        // Handles exceptions during SOAP message processing.
        // Creates a SoapServiceResult<T> with the correct generic type to match the method's return type.
        // Define SOAP header class for AuthToken

        private void HandleAuth(SoapMessage message)
        {
            HttpContext.Current.Items["AuthToken"] = string.Empty;

            if (message == null)
            {
                ThrowSoapTokenException(new CustomException("SOAP message is null."));
            }


            // Get the method being called
            UserLevelEnum[] allowedRoles = null;
            var method = GetMethodFromMessage(message);
            if (method == null)
            {
                ThrowSoapTokenException(new CustomException("Method information is not available in the SOAP message."));
            }

            var authorizeRoleAttribute = method.GetCustomAttributes(typeof(AuthorizeRoleAttribute), false)
                             .FirstOrDefault() as AuthorizeRoleAttribute;

            // If no AuthorizeRole attribute, allow access to everyone
            if (authorizeRoleAttribute == null)
                return;

            allowedRoles = authorizeRoleAttribute.AllowedRoles;
            // Check if user role is allowed
            if (allowedRoles.Length < 1)
            {
                ThrowSoapTokenException(new ForbiddenException($"The method defination is allowed none users. It copuld be defined on porpuse to make it unavailable."));

            }

            string authHeader = GetAuthHeaderFromSoapHeader(message);
            // If AuthorizeRole attribute exists, authentication is required
            if (string.IsNullOrEmpty(authHeader))
                ThrowSoapTokenException(new UnauthorizedException("AuthorizationHeader is missing for restricted method."));

            AuthenticatedUserDto user = null;
            if (authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                user = BasicAuth(authHeader.Substring("Basic ".Length));
            else if (authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                user = JwtTokenAuth(authHeader.Substring("Bearer ".Length));


            if (user == null || user.UID <= 0)
                ThrowSoapTokenException(new UnauthorizedException("Invalid or expired Authorization"));

            // Check if user role is allowed
            if (!allowedRoles.Contains(user.UserLevel))
                ThrowSoapTokenException(new ForbiddenException($"User role '{user.UserLevel}' is not authorized for this operation."));
        }
        private AuthenticatedUserDto BasicAuth(string encodedCredentials)
        {
            string credentials = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            string[] usernamePassword = credentials.Split(':');

            if (usernamePassword.Length == 2)
            {
                string username = usernamePassword[0];
                string password = usernamePassword[1];

                // Validate credentials and generate JWT token (replace with your logic)
                var authServise = new AuthSoapService();
                var loginResult = authServise.Login(username, password);
                if (loginResult.Success && loginResult.Data != null && loginResult.Data.UID > 0)
                {
                    HttpContext.Current.Items["AuthenticatedUser"] = loginResult.Data;
                    HttpContext.Current.Items["AuthToken"] = loginResult.Data.Token;
                    return loginResult.Data;
                }
            }

            ThrowSoapTokenException(new UnauthorizedException("Invalid or expired user credentials."));
            return null;
        }
        private AuthenticatedUserDto JwtTokenAuth(string token)
        {
            var user = JwtHelper.ValidateToken(token);
            if (user != null && user.UID > 0)
            {
                HttpContext.Current.Items["AuthenticatedUser"] = user;
                HttpContext.Current.Items["AuthToken"] = token;

                var authServise = new AuthSoapService();
                var result = authServise.RefreshToken();

                if (result.Success && result.Data != null && result.Data.UID > 0)
                {
                    HttpContext.Current.Items["AuthenticatedUser"] = result.Data;
                    HttpContext.Current.Items["AuthToken"] = result.Data.Token;
                    return result.Data;
                }
            }

            ThrowSoapTokenException(new UnauthorizedException("Invalid or expired token."));
            return null;
        }
        private string GetAuthHeaderFromSoapHeader(SoapMessage message)
        {
            var headers = message.Headers;
            foreach (SoapUnknownHeader header in message.Headers)
            {
                if (header.Element.Name == "Authorization")
                {
                    string headerValue = header.Element.InnerText?.Trim();
                    return headerValue;
                }
            }

            return string.Empty;
        }
        private MethodBase GetMethodFromMessage(SoapMessage message)
        {
            if (message is SoapServerMessage serverMessage && serverMessage.MethodInfo != null)
            {
                return serverMessage.MethodInfo.MethodInfo; // LogicalMethodInfo → MethodInfo → MethodBase
            }
            return null;
        }

        #endregion

        #region Log & Exception handling
        // Lazy-initialized logging service for recording exceptions.
        private ILogService _logService;

        // Property to access the logging service, initializing it if null.
        protected ILogService LogService
        {
            get
            {
                if (_logService == null)
                {
                    _logService = new LogService();
                }
                return _logService;
            }
        }
        // Handles exceptions during SOAP message processing.
        // Creates a SoapServiceResult<T> with the correct generic type to match the method's return type.
        private void HandleException(SoapMessage message)
        {
            // Exit if no exception exists.
            if (message.Exception == null)
                return;

            LogService.LogException(message.Exception);
            var userMsg = LogService.GetUserFriendlyMessage(message.Exception);
            var faultCode = SoapException.ServerFaultCode;
            var detail = CreateSoapDetailElement(userMsg);
            var soapEx = new SoapException(userMsg, faultCode, message.Url, detail);
            message.Exception = soapEx;
        }
        private void ThrowSoapTokenException(CustomException ex)
        {
            // Exit if no exception exists.

            var userMsg = ex.GetUserFriendlyMessage();
            var faultCode = SoapException.ClientFaultCode;
            var detail = CreateSoapDetailElement(userMsg);
            var soapEx = new SoapException(userMsg, faultCode, _message.Url, detail);
            _message.Exception = soapEx;
            throw soapEx;
        }
        #endregion
        private XmlNode CreateSoapDetailElement(string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement detailNode = doc.CreateElement("Detail");
            XmlElement msgElement = doc.CreateElement("Message");
            msgElement.InnerText = message;
            detailNode.AppendChild(msgElement);
            return detailNode;
        }
    }
}