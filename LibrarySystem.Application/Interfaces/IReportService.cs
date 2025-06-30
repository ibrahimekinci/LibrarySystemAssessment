using LibrarySystem.BLL.DTOs;
using System.Data;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IReportService
    {
        PagedResultDto<DataTable> GetMostBorrowedBooks(PagedRequestDto pagedRequestDto);
        PagedResultDto<DataTable> GetOverdueBooks(PagedRequestDto pagedRequestDto);
        PagedResultDto<DataTable> GetBorrowedBooksByCategory(PagedRequestDto pagedRequestDto);
    }
}
