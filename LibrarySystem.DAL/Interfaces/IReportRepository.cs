using LibrarySystem.DAL.DTOs;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IReportRepository
    {
        PagedResultDto<DataTable> GetMostBorrowedBooksPaged(PagedRequestDto request);
        PagedResultDto<DataTable> GetOverdueBooksPaged(PagedRequestDto request);
        PagedResultDto<DataTable> GetBorrowedBooksByCategoryPaged(PagedRequestDto request);
    }
}
