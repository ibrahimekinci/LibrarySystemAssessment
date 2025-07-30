using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface ILanguageSoapService
    {
        [OperationContract]
        SoapServiceResult<List<LanguageViewDto>> GetAll();

        [OperationContract]
        SoapServiceResult<LanguageViewDto> GetById(int id);

        [OperationContract]
        SoapServiceResult<LanguageViewDto> Add(LanguageCreateDto dto);

        [OperationContract]
        SoapServiceResult<LanguageViewDto> Update(LanguageUpdateDto dto);

        [OperationContract]
        SoapServiceResult<bool> Delete(int languageId);
    }
}
