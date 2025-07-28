using LibrarySystem.Abstractions.Repositories;
using LibrarySystem.DAL.DataSets.ReportDataSetTableAdapters;
using LibrarySystem.DAL.Helpers;
using System.Data;

namespace LibrarySystem.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        #region TableAdapter Properties – Reports

        // Borrowed by Category Report
        private ViewReportBorrowedBooksByCategoryTableAdapter _viewReportBorrowedBooksByCategoryTableAdapter;
        private ViewReportBorrowedBooksByCategoryTableAdapter ViewReportBorrowedBooksByCategoryTableAdapter
        {
            get
            {
                if (_viewReportBorrowedBooksByCategoryTableAdapter == null)
                {
                    _viewReportBorrowedBooksByCategoryTableAdapter = new ViewReportBorrowedBooksByCategoryTableAdapter();
                    _viewReportBorrowedBooksByCategoryTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewReportBorrowedBooksByCategoryTableAdapter;
            }
        }

        // Most Borrowed Books Report
        private ViewReportMostBorrowedBooksTableAdapter _viewReportMostBorrowedBooksTableAdapter;
        private ViewReportMostBorrowedBooksTableAdapter ViewReportMostBorrowedBooksTableAdapter
        {
            get
            {
                if (_viewReportMostBorrowedBooksTableAdapter == null)
                {
                    _viewReportMostBorrowedBooksTableAdapter = new ViewReportMostBorrowedBooksTableAdapter();
                    _viewReportMostBorrowedBooksTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewReportMostBorrowedBooksTableAdapter;
            }
        }

        // Overdue Books Report
        private ViewReportOverdueBooksTableAdapter _viewReportOverdueBooksTableAdapter;
        private ViewReportOverdueBooksTableAdapter ViewReportOverdueBooksTableAdapter
        {
            get
            {
                if (_viewReportOverdueBooksTableAdapter == null)
                {
                    _viewReportOverdueBooksTableAdapter = new ViewReportOverdueBooksTableAdapter();
                    _viewReportOverdueBooksTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewReportOverdueBooksTableAdapter;
            }
        }

        #endregion

        public DataTable GetBorrowedBooksByCategory()
        {
            var table = ViewReportBorrowedBooksByCategoryTableAdapter.GetData();
            return table;
        }

        public DataTable GetMostBorrowedBooks()
        {
            var table = ViewReportMostBorrowedBooksTableAdapter.GetData();
            return table;
        }

        public DataTable GetOverdueBooks()
        {
            var table = ViewReportOverdueBooksTableAdapter.GetData();
            return table;
        }
    }
}
