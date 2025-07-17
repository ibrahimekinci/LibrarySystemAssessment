using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class BarrowService :  BaseService, IBarrowService
    {
        public int BorrowBook(BarrowCreateDto barrowRecord)
        {
            throw new System.NotImplementedException();
        }

        public List<BookViewDto> GetBorrowedBooksByUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnBook(BarrowUpdateDto barrowRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}
