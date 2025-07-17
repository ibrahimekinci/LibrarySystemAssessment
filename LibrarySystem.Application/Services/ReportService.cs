using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using System.Data;

namespace LibrarySystem.BLL.Services
{
    public class ReportService : BaseService, IReportService
    {

        public DataTable GetBorrowedBooksByCategory()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetMostBorrowedBooks()
        {
            throw new System.NotImplementedException();
        }
        public DataTable GetOverdueBooks()
        {
            throw new System.NotImplementedException();
        }
    }
}
