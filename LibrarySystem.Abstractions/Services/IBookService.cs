using LibrarySystem.Abstractions.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Services
{
    public interface IBookService
    {
        List<BookViewDto> GetAll();
        BookViewDto GetByISBN(string isbn);
        int Add(BookDto book);
        bool Update(BookDto book);
        bool Delete(string isbn);
        List<BookViewDto> Search(BookSearchCriteriaDto dto);

        List<BookViewDto> GetAvailableBooks();
        BookViewDto GetAvailableBookByISBN(string ISBN);
        BookViewDto GetBorrowedBookByUserIdAndISBN(int UID, string ISBN);
    }
}
