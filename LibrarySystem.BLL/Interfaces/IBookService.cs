using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IBookService
    {
        List<BookViewDto> GetAll();
        BookViewDto GetByISBN(string isbn);
        BookViewDto GetById(int id);
        int AddBook(BookDto book);
        bool UpdateBook(BookDto book);
        bool DeleteBook(string isbn);
        List<BookViewDto> Search(BookSearchCriteriaDto dto);
        List<BookViewDto> GetAvailableBooks();
        List<BookViewDto> GetBorrowedBooks();
    }
}
