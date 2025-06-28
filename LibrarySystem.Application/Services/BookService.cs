using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Interfaces;
using System;
namespace LibrarySystem.Application.Services
{
    public class BookService : IBookService
    {
        public int AddBook(BookDto book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(string isbn)
        {
            throw new NotImplementedException();
        }

        public PagedResultDataTableDto<BookViewDto> GetAllBooks(PagedRequestDto pagedRequestDto)
        {
            throw new NotImplementedException();
        }

        public BookViewDto GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public BookViewDto GetBookByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public PagedResultDataTableDto<BookViewDto> SearchBooks(PagedRequestDto pagedRequestDto, BookSearchCriteriaDto dto)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
