using System.Data;

namespace LibrarySystem.Abstractions.Services
{
    public interface IReportService
    {
        DataTable GetMostBorrowedBooks();
        DataTable GetOverdueBooks();
        DataTable GetBorrowedBooksByCategory();
    }
}
