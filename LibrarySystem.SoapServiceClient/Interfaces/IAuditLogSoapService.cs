using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IAuditLogSoapService
    {
        //[OperationContract]
        //SoapServiceResult<bool> Log(AuditActionType actionType, int? userId, string details);

        [OperationContract]
        SoapServiceResult<bool> LogWithDto(AuditLogDto log);
    }
}
