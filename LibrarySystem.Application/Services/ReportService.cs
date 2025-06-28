using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Interfaces;
using System.Data;

namespace LibrarySystem.Application.Services
{
    public class ReportService : IReportService
    {
        public PagedResultDataTableDto<DataTable> GetBorrowedBooksByCategory(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<DataTable> GetMostBorrowedBooks(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<DataTable> GetOverdueBooks(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
