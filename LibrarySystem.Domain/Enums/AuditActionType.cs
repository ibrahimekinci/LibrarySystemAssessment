namespace LibrarySystem.Domain.Enums
{
    public enum AuditActionType
    {
        Unknown = -1,

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
        ManageLanguages
    }

}
