using System.Data;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IReportService
    {
        DataTable GetMostBorrowedBooks();
        DataTable GetOverdueBooks();
        DataTable GetBorrowedBooksByCategory();
    }
}
