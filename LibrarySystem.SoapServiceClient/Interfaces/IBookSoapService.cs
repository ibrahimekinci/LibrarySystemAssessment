using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.SoapServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.SoapServiceClient.Interfaces
{
    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IBookSoapService
    {
        [OperationContract]
        SoapServiceResult<List<BookViewDto>> GetAll();

        [OperationContract]
        SoapServiceResult<BookViewDto> GetByISBN(string isbn);

        [OperationContract]
        SoapServiceResult<BookViewDto> Add(BookDto dto);

        [OperationContract]
        SoapServiceResult<BookViewDto> Update(BookDto dto);

        [OperationContract]
        SoapServiceResult<bool> Delete(string isbn);

        [OperationContract]
        SoapServiceResult<List<BookViewDto>> Search(BookSearchCriteriaDto dto);

        [OperationContract]
        SoapServiceResult<List<BookViewDto>> GetAvailableBooks();

        [OperationContract]
        SoapServiceResult<BookViewDto> GetAvailableBookByISBN(string isbn);

        [OperationContract]
        SoapServiceResult<BookViewDto> GetBorrowedBookByUserIdAndISBN(int userId, string isbn);
    }
}
