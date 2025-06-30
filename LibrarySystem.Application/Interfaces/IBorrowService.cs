using LibrarySystem.BLL.DTOs;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IBorrowService
    {
        int BorrowBook(BarrowCreateDto barrowRecord);
        void ReturnBook(BarrowUpdateDto barrowRecord);
        PagedResultDto<BookViewDto> GetBorrowedBooksByUser(PagedRequestDto pagedRequestDto, int userId);
    }

}
