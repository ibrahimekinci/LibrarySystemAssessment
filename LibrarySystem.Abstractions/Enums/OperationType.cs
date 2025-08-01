namespace LibrarySystem.Abstractions.Enums
{
    public enum OperationType
    {
        Unknown = 0,

        // Authentication
        Login = 1,
        Logout = 5,
        UnauthorizedAccess = 10,

        // Book Operations
        BookCreate = 15,
        BookEdit = 20,
        BookDelete = 25,
        BookSearch = 30,
        BookBorrow = 35,
        BookReturn = 40,
        BookReserve = 45,
        BookCancelReservation = 50,

        // User Operations
        UserCreate = 55,
        UserUpdate = 60,
        ProfileUpdate = 65,
        UserResetPassword = 70,
        UserViewAll = 75,

        // Author Operations
        AuthorCreate = 80,
        AuthorEdit = 85,
        AuthorDelete = 90,
        AuthorViewAll = 95,

        // Category Operations
        CategoryCreate = 100,
        CategoryEdit = 105,
        CategoryDelete = 110,
        CategoryViewAll = 115,

        // Language Operations
        LanguageCreate = 120,
        LanguageEdit = 125,
        LanguageDelete = 130,
        LanguageViewAll = 135,

        // Borrowing & Returning
        BorrowBook = 140,
        ReturnBook = 145,
        DeleteBookLoan = 150,
        ViewMyBookLoans = 155,
        ViewAllBookLoans = 160,

        // Reservation
        ReserveBook = 165,
        UpdateReservation = 170,
        DeleteReservation = 175,
        ViewMyReservations = 180,
        ViewAllReservations = 185,

        // Reports
        GetReportMostBorrowedBooks = 190,
        GetReportOverdueBooks = 195,
        GetReportBorrowedBooksByCategory = 200,

        // UI/Navigation
        NavigateDashboard = 205,
        NavigateLogin = 210,
        NavigateUnauthorized = 215,
        NavigateUserManagement = 220,
        NavigateBookManagement = 225,
        NavigateReports = 230
    }
}
