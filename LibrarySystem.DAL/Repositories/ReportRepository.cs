using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Data;

namespace LibrarySystem.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        public PagedResultDto<DataTable> GetBorrowedBooksByCategoryPaged(PagedRequestDto request)
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<DataTable> GetMostBorrowedBooksPaged(PagedRequestDto request)
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<DataTable> GetOverdueBooksPaged(PagedRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
