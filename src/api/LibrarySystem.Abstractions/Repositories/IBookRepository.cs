using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Repositories
{
    public interface IBookRepository
    {
        //PagedResultDto<List<BookEntity>> GetAllPaged(PagedRequestDto request);
        List<BookEntity> GetAll();
        List<BookEntity> GetAllBookBorrowed();
        List<BookEntity> GetAllBookAvailable();
        List<BookEntity> Search(BookSearchCriteriaDto dto);
        BookEntity GetByISBN(string isbn);
        BookEntity GetAvailableBookByISBN(string isbn);
        BookEntity GetBorrowedBookByUserIdAndISBN(int userId, string isbn);
        string Add(BookEntity book);
        bool Update(BookEntity book);
        bool Delete(string isbn);
    }
}
