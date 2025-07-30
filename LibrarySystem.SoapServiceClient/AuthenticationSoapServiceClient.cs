using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Interfaces;
using LibrarySystem.SoapServiceClient.Models;
using System;
using System.Runtime.Remoting;

namespace LibrarySystem.SoapServiceClient
{
    public class AuthenticationSoapServiceClient : SoapClientBase<Interfaces.IAuthenticationSoapService>
    {
        private readonly static string _endpointUrl = $"{BaseUrl}Services/AuthSoapService.asmx";
        public AuthenticationSoapServiceClient() : base(_endpointUrl, string.Empty) { }

        public SoapServiceResult<AuthenticatedUserDto> Login(string username, string password)
        {
            var authClient = new LibrarySystemSoapApi.AuthSoapServiceSoapClient(); // No token
            var result = authClient.Login(username, password);

            return null;
        }
    }
}
