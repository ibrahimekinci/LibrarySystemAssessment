using LibrarySystem.DAL.DTOs;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IReportRepository
    {
        //PagedResultDto<DataTable> GetMostBorrowedBooks_AllPaged(PagedRequestDto request);
        //PagedResultDto<DataTable> GetOverdueBooks_AllPaged(PagedRequestDto request);
        //PagedResultDto<DataTable> GetBorrowedBooksByCategory_AllPaged(PagedRequestDto request);
        DataTable GetMostBorrowedBooks();
        DataTable GetOverdueBooks();
        DataTable GetBorrowedBooksByCategory();
    }
}
