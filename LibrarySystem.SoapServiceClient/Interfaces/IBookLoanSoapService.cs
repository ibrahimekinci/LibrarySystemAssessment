using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IBookLoanSoapService
    {
        [OperationContract]
        SoapServiceResult<BorrowViewDto> Borrow(BorrowCreateDto dto);

        [OperationContract]
        SoapServiceResult<BorrowViewDto> Return(BorrowReturnDto dto);

        [OperationContract]
        SoapServiceResult<BorrowViewDto> GetById(int id);

        [OperationContract]
        SoapServiceResult<DataTable> GetUnreturnedLoansByUserId(int userId);

        [OperationContract]
        SoapServiceResult<DataTable> GetAll();

        [OperationContract]
        SoapServiceResult<DataTable> GetAllByUserId(int userId);

        [OperationContract]
        SoapServiceResult<bool> Delete(int borrowId);
    }
}
