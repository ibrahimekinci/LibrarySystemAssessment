using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface ICategorySoapService
    {
        [OperationContract]
        SoapServiceResult<List<CategoryViewDto>> GetAll();

        [OperationContract]
        SoapServiceResult<CategoryViewDto> GetById(int id);

        [OperationContract]
        SoapServiceResult<CategoryViewDto> Add(CategoryCreateDto dto);

        [OperationContract]
        SoapServiceResult<CategoryViewDto> Update(CategoryUpdateDto dto);

        [OperationContract]
        SoapServiceResult<bool> Delete(int categoryId);
    }
}
