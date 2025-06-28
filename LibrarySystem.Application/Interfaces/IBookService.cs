using LibrarySystem.Application.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Application.Interfaces
{
    public interface IBookService
    {
        PagedResultDataTableDto<BookViewDto> GetAllBooks(PagedRequestDto pagedRequestDto);
        BookViewDto GetBookByISBN(string isbn);
        BookViewDto GetBookById(int id);
        int AddBook(BookDto book);
        void UpdateBook(BookDto book);
        void DeleteBook(string isbn);
        PagedResultDataTableDto<BookViewDto> SearchBooks(PagedRequestDto pagedRequestDto, BookSearchCriteriaDto dto);
    }
}
