using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract]
    public interface IAuthenticationSoapService
    {
        [OperationContract]
        SoapServiceResult<AuthenticatedUserDto> Login(string username, string password);
    }
}
