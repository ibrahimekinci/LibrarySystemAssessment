using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IBarrowService
    {
        int BorrowBook(BarrowCreateDto barrowRecord);
        bool ReturnBook(BarrowUpdateDto barrowRecord);
        List<BookViewDto> GetBorrowedBooksByUser(int userId);
        bool DeleteBorrow(int borrowId);
    }

}
