using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;

namespace LibrarySystem.BLL.Services
{
    public class BorrowService :  BaseService, IBorrowService
    {
        public int BorrowBook(BarrowCreateDto barrowRecord)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDto<BookViewDto> GetBorrowedBooksByUser(PagedRequestDto pagedRequestDto, int userId)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnBook(BarrowUpdateDto barrowRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}
