using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using System.Data;

namespace LibrarySystem.BLL.Services
{
    public class ReportService : BaseService, IReportService
    {
        public PagedResultDto<DataTable> GetBorrowedBooksByCategory(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDto<DataTable> GetMostBorrowedBooks(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDto<DataTable> GetOverdueBooks(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
