using LibrarySystem.DAL.DataSets.ReportDataSetTableAdapters;
using LibrarySystem.DAL.Interfaces;
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
            if (table == null)
                return null;
            return table;
        }

        public DataTable GetMostBorrowedBooks()
        {
            var table = viewReportMostBorrowedBooksTableAdapter.GetData();
            if (table == null)
                return null;
            return table;
        }

        public DataTable GetOverdueBooks()
        {
            var table = viewReportOverdueBooksTableAdapter.GetData();
            if (table == null)
                return null;
            return table;
        }
    }
}
