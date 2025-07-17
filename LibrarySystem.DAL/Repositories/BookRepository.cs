using LibrarySystem.DAL.DataSets.BookDataSetTableAdapters;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {

        private readonly TabBookTableAdapter tableAdapter = new TabBookTableAdapter();
        private readonly ViewBookTableAdapter ViewAdapter = new ViewBookTableAdapter();
        private readonly ViewBookAvailableTableAdapter _viewBookAvailableAdapter = new ViewBookAvailableTableAdapter();
        private readonly ViewBookBorrowedTableAdapter _viewBookBorrowedAdapter = new ViewBookBorrowedTableAdapter();

        public BookEntity GetByISBN(string isbn)
        {
            return ViewAdapter.GetDataByISBN("ISBN").ToList<BookEntity>().FirstOrDefault();
        }
        public List<BookEntity> GetAll()
        {
            return ViewAdapter.GetData().ToList<BookEntity>();
        }
        public List<BookEntity> Search(BookSearchCriteriaDto dto)
        {
            return ViewAdapter.GetDataBySearchCriterias(dto.BookName, dto.AuthorName, dto.CategoryId.ToString()).ToList<BookEntity>();
        }

        public List<BookEntity> GetAllBookBorrowed()
        {
            return _viewBookBorrowedAdapter.GetData().ToList<BookEntity>();
        }

        public List<BookEntity> GetAllBookAvailable()
        {
            return _viewBookAvailableAdapter.GetData().ToList<BookEntity>();
        }

        public string Add(BookEntity book)
        {
            var id = tableAdapter.InsertCustom(book.ISBN, book.BookName, book.Author, book.Category, book.Language, book.PublishYear, book.Pages, book.Publisher);
            return 0 < id ? book.ISBN : "";
        }

        public bool Update(BookEntity book)
        {
            return 0 < tableAdapter.UpdateById(book.BookName, book.Author, book.Category, book.Language, book.PublishYear, book.Pages, book.Publisher, book.ISBN);
        }

        public bool Delete(string isbn)
        {
            return 0 < tableAdapter.DeleteByISBN(isbn);
        }
    }
}
