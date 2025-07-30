using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IAuthorSoapService
    {
        [OperationContract]
        SoapServiceResult<AuthorViewDto> Add(AuthorCreateDto dto);

        [OperationContract]
        SoapServiceResult<AuthorViewDto> Update(AuthorUpdateDto dto);

        [OperationContract]
        SoapServiceResult<bool> Delete(int id);

        [OperationContract]
        SoapServiceResult<List<AuthorViewDto>> GetAll();

        [OperationContract]
        SoapServiceResult<AuthorViewDto> GetById(int id);
    }
}
