namespace LibrarySystem.Domain.Enums
{
    public enum OperationType
    {
        // Authentication
        Login,
        Logout,
        UnauthorizedAccess,

        // Book Operations
        BookCreate,
        BookEdit,
        BookDelete,
        BookSearch,
        BookBorrow,
        BookReturn,
        BookReserve,
        BookCancelReservation,

        // User Operations
        UserCreate,
        UserUpdate,
        UserResetPassword,
        UserViewAll,

        // Author Operations
        AuthorCreate,
        AuthorEdit,
        AuthorDelete,
        AuthorViewAll,

        // Category Operations
        CategoryCreate,
        CategoryEdit,
        CategoryDelete,
        CategoryViewAll,

        // Language Operations
        LanguageCreate,
        LanguageEdit,
        LanguageDelete,
        LanguageViewAll,

        // Borrowing & Returning
        BorrowBook,
        ReturnBook,
        //DeleteBorrowRecord,
        //ViewBorrowedBooksByUser,

        // Reservation
        ReserveBook,
        UpdateReservation,
        CancelReservation,
        ViewUserReservations,

        // Reports
        GetReportMostBorrowedBooks,
        GetReportOverdueBooks,
        GetReportBorrowedBooksByCategory,

        // UI/Navigation
        NavigateDashboard,
        NavigateLogin,
        NavigateUnauthorized,
        NavigateUserManagement,
        NavigateBookManagement,
        NavigateReports
    }
}

