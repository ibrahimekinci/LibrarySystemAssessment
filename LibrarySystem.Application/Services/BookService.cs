using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using LibrarySystem.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class BookService : BaseService, IBookService
    {
        IBookRepository repo = new BookRepository();
        public int AddBook(BookDto book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(string isbn)
        {
            throw new NotImplementedException();
        }

        public List<BookViewDto> GetAll()
        {
            List<BookEntity> resultEntities = repo.GetAll();
            var result = Mapper.Map<List<BookViewDto>>(resultEntities ?? new List<BookEntity>());
            return result;
        }

        public BookViewDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BookViewDto GetByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public List<BookViewDto> Search(BookSearchCriteriaDto dto)
        {
            var repoDto = Mapper.Map<DAL.DTOs.BookSearchCriteriaDto>(dto);
            List<BookEntity> resultEntities = repo.Search(repoDto);
            var result = Mapper.Map<List<BookViewDto>>(resultEntities ?? new List<BookEntity>());
            return result;
        }

        public void UpdateBook(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
