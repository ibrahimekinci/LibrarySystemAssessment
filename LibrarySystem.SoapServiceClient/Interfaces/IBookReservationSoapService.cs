using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System.Data;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IBookReservationSoapService
    {
        [OperationContract]
        SoapServiceResult<ReserveViewDto> Reserve(ReserveCreateDto dto);

        [OperationContract]
        SoapServiceResult<ReserveViewDto> UpdateReservation(ReserveUpdateDto dto);

        [OperationContract]
        SoapServiceResult<ReserveViewDto> GetById(int id);

        [OperationContract]
        SoapServiceResult<DataTable> GetAll();

        [OperationContract]
        SoapServiceResult<DataTable> GetAllByUserId(int userId);

        [OperationContract]
        SoapServiceResult<bool> CancelReservation(int id);
    }

}
