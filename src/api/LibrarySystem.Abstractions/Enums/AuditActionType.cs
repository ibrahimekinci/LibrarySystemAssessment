namespace LibrarySystem.Abstractions.Enums
{
    public enum AuditActionType
    {
        Unknown = 0,

        ApplicationException = 1,
        ApplicationStarted = 5,
        ApplicationEnded = 10,
        Login = 15,
        Logout = 20,

        CreateBook = 25,
        EditBook = 30,
        DeleteBook = 35,
        SearchBook = 40,
        ReserveBook = 45,
        BorrowBook = 50,
        ReturnBook = 55,

        ViewAvailableBooks = 60,
        ViewBorrowedBooks = 65,

        GetReportMostBorrowedBooks = 70,
        GetReportOverdueBooks = 75,
        GetReportBorrowedBooksByCategory = 80,

        AccessUnauthorizedPage = 85,

        ManageUsers = 90,
        ManageAuthors = 95,
        ManageCategories = 100,
        ManageLanguages = 105
    }
}
