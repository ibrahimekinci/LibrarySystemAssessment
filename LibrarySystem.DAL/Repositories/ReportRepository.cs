using LibrarySystem.DAL.DataSets.ReportDataSetTableAdapters;
using LibrarySystem.Abstractions.Repositories;
using System.Data;

namespace LibrarySystem.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ViewReportBorrowedBooksByCategoryTableAdapter viewReportBorrowedBooksByCategoryTableAdapter = new ViewReportBorrowedBooksByCategoryTableAdapter();
        private readonly ViewReportMostBorrowedBooksTableAdapter viewReportMostBorrowedBooksTableAdapter = new ViewReportMostBorrowedBooksTableAdapter();
        private readonly ViewReportOverdueBooksTableAdapter viewReportOverdueBooksTableAdapter = new ViewReportOverdueBooksTableAdapter();

        public DataTable GetBorrowedBooksByCategory()
        {
            var table = viewReportBorrowedBooksByCategoryTableAdapter.GetData();
            return table;
        }

        public DataTable GetMostBorrowedBooks()
        {
            var table = viewReportMostBorrowedBooksTableAdapter.GetData();
            return table;
        }

        public DataTable GetOverdueBooks()
        {
            var table = viewReportOverdueBooksTableAdapter.GetData();
            return table;
        }
    }
}
