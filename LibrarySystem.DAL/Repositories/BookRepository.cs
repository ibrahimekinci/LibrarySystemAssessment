using LibrarySystem.DAL.DataSets.BookDataSetTableAdapters;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Abstractions.Repositories;
using System.Collections.Generic;
using System.Data;
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
            var table = ViewAdapter.GetDataByISBN(isbn);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>().FirstOrDefault();
        }
        public List<BookEntity> GetAll()
        {
            var table = ViewAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }
        public List<BookEntity> Search(BookSearchCriteriaDto dto)
        {
            var table = ViewAdapter.GetDataBySearchCriterias(dto.BookName, dto.AuthorName, dto.CategoryId.ToString());
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }

        public List<BookEntity> GetAllBookBorrowed()
        {
            var table = _viewBookBorrowedAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }

        public List<BookEntity> GetAllBookAvailable()
        {
            var table = _viewBookAvailableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
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

        public BookEntity GetAvailableBookByISBN(string isbn)
        {
            var table = _viewBookAvailableAdapter.GetByISBN(isbn);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>().FirstOrDefault();
        }

        public BookEntity GetBorrowedBookByUserIdAndISBN(int userId, string isbn)
        {
            var table = _viewBookBorrowedAdapter.GetByUserIdAndISBN(userId, isbn);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>().FirstOrDefault();
        }
    }
}
