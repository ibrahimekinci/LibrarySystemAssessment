using LibrarySystem.Application.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Application.Interfaces
{
    public interface IBorrowService
    {
        int BorrowBook(BarrowRecordCreateDto barrowRecord);
        void ReturnBook(BarrowRecordUpdateDto barrowRecord);
        PagedResultDataTableDto<BookViewDto> GetBorrowedBooksByUser(PagedRequestDto pagedRequestDto, int userId);
    }

}
