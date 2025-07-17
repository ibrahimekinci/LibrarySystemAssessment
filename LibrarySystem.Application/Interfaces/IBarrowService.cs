using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IBarrowService
    {
        int BorrowBook(BarrowCreateDto barrowRecord);
        void ReturnBook(BarrowUpdateDto barrowRecord);
        List<BookViewDto> GetBorrowedBooksByUser(int userId);
    }

}
