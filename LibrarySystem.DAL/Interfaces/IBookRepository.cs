using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IBookRepository
    {
        BookEntity GetByISBN(string isbn);
        List<BookEntity> GetAll();
        List<BookEntity> Search(BookSearchCriteriaDto dto);
        int Add(BookEntity book);
        void Update(BookEntity book);
        void Delete(string isbn);
    }
}
