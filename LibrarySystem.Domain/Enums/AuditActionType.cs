using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Enums
{
    public enum AuditActionType
    {
        ApplicationException,
        ApplicationStarted,
        ApplicationEnded,
        Login,
        Logout,
        CreateBook,
        EditBook,
        DeleteBook,
        SearchBook,
        ReserveBook,
        BorrowBook,
        ReturnBook,
        ViewAvailableBooks,
        ViewBorrowedBooks,
        GetReportMostBorrowedBooks,
        GetReportOverdueBooks,
        GetReportBorrowedBooksByCategory,
        AccessUnauthorizedPage,
        ManageUsers,
        ManageAuthors,
        ManageCategories,
        ManageLanguages,
        Unknown
    }

}
