using LibrarySystem.Application.DTOs;
using System.Data;

namespace LibrarySystem.Application.Interfaces
{
    public interface IReportService
    {
        PagedResultDataTableDto<DataTable> GetMostBorrowedBooks(PagedRequestDto pagedRequestDto);
        PagedResultDataTableDto<DataTable> GetOverdueBooks(PagedRequestDto pagedRequestDto);
        PagedResultDataTableDto<DataTable> GetBorrowedBooksByCategory(PagedRequestDto pagedRequestDto);
    }
}
