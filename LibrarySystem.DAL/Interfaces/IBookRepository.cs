using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IBookRepository
    {
        //PagedResultDto<List<BookEntity>> GetAllPaged(PagedRequestDto request);
        List<BookEntity> GetAll();
        List<BookEntity> GetAllBookBorrowed();
        List<BookEntity> GetAllBookAvailable();
        List<BookEntity> Search(BookSearchCriteriaDto dto);
        BookEntity GetByISBN(string isbn);
        string Add(BookEntity book);
        bool Update(BookEntity book);
        bool Delete(string isbn);
    }
}
