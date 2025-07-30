using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class BookService : BaseService, IBookService
    {
        public List<BookViewDto> GetAll()
        {
            var entities = BookRepository.GetAll();
            return Mapper.Map<List<BookViewDto>>(entities);
        }

        public BookViewDto GetByISBN(string isbn)
        {
            var entity = BookRepository.GetByISBN(isbn);
            return Mapper.Map<BookViewDto>(entity);
        }
        public int Add(BookDto book)
        {
            var existEntity = BookRepository.GetByISBN(book.ISBN);
            if (existEntity != null && !string.IsNullOrEmpty(existEntity.ISBN))
                throw new ConflictException("ISBN is already being used.");

            var entity = Mapper.Map<BookEntity>(book);
            var result = BookRepository.Add(entity);
            return string.IsNullOrWhiteSpace(result) ? 0 : 1;
        }

        public bool Update(BookDto book)
        {
            var entity = Mapper.Map<BookEntity>(book);
            return BookRepository.Update(entity);
        }

        public bool Delete(string isbn)
        {
            return BookRepository.Delete(isbn);
        }

        public List<BookViewDto> Search(BookSearchCriteriaDto dto)
        {
            var result = BookRepository.Search(dto);
            return Mapper.Map<List<BookViewDto>>(result);
        }

        public List<BookViewDto> GetAvailableBooks()
        {
            var entities = BookRepository.GetAllBookAvailable();
            return Mapper.Map<List<BookViewDto>>(entities);
        }
        public BookViewDto GetAvailableBookByISBN(string isbn)
        {
            var entity = BookRepository.GetAvailableBookByISBN(isbn);
            return Mapper.Map<BookViewDto>(entity);
        }
        public BookViewDto GetBorrowedBookByUserIdAndISBN(int UID, string ISBN)
        {
            var entity = BookRepository.GetBorrowedBookByUserIdAndISBN(UID, ISBN);
            return Mapper.Map<BookViewDto>(entity);
        }
    }
}
