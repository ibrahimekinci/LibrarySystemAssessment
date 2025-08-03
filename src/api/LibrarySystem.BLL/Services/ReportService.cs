using LibrarySystem.Abstractions.Services;
using System.Data;

namespace LibrarySystem.BLL.Services
{
    public class ReportService : BaseService, IReportService
    {
        public ReportService()
        {
        }

        public DataTable GetMostBorrowedBooks()
        {
            return ReportRepository.GetMostBorrowedBooks();
        }

        public DataTable GetOverdueBooks()
        {
            return ReportRepository.GetOverdueBooks();
        }

        public DataTable GetBorrowedBooksByCategory()
        {
            return ReportRepository.GetBorrowedBooksByCategory();
        }
    }
}
