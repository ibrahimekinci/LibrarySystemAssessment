using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Interfaces;

namespace LibrarySystem.Application.Services
{
    public class BorrowService : IBorrowService
    {
        public int BorrowBook(BarrowRecordCreateDto barrowRecord)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<BookViewDto> GetBorrowedBooksByUser(PagedRequestDto pagedRequestDto, int userId)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnBook(BarrowRecordUpdateDto barrowRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}
