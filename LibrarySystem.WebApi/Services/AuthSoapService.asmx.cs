using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Models;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for AuthSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthSoapService : BaseSoapService
    {

        [WebMethod(Description = "Authenticate user and return JWT token.")]
        public SoapServiceResult<AuthenticatedUserDto> Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return SoapServiceResult<AuthenticatedUserDto>.Fail("Please enter both username and password.");

                var result = AuthenticationService.Login(username, password);
                if (result != null && result.UID > 0)
                    return SoapServiceResult<AuthenticatedUserDto>.Ok(result, "Login successful.");

                return SoapServiceResult<AuthenticatedUserDto>.Fail("Invalid username or password.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<AuthenticatedUserDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
