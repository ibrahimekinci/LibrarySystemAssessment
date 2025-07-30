using LibrarySystem.SoapServiceClient.Models;
using System.Data;
using System.ServiceModel;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IReportSoapService
    {
        [OperationContract]
        SoapServiceResult<DataTable> GetMostBorrowedBooks();

        [OperationContract]
        SoapServiceResult<DataTable> GetOverdueBooks();

        [OperationContract]
        SoapServiceResult<DataTable> GetBorrowedBooksByCategory();
    }
}
