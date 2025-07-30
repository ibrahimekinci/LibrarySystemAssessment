using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IUserSoapService
    {
        [OperationContract]
        SoapServiceResult<UserViewDto> Register(UserCreateDto dto);

        [OperationContract]
        SoapServiceResult<UserViewDto> UpdateUser(UserUpdateDto dto);

        [OperationContract]
        SoapServiceResult<UserViewDto> ResetPassword(UserPasswordUpdateDto dto);

        [OperationContract]
        SoapServiceResult<List<UserViewDto>> GetAll();

        [OperationContract]
        SoapServiceResult<UserViewDto> GetById(int userId);

        [OperationContract]
        SoapServiceResult<bool> Delete(int userId);
    }
}
