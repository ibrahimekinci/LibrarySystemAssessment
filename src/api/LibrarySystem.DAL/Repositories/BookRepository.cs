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

        #region TableAdapter Properties

        private TabBookTableAdapter _tabBookTableAdapter;
        private TabBookTableAdapter TabBookTableAdapter
        {
            get
            {
                if (_tabBookTableAdapter == null)
                {
                    _tabBookTableAdapter = new TabBookTableAdapter();
                    _tabBookTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabBookTableAdapter;
            }
        }

        private ViewBookTableAdapter _viewBookTableAdapter;
        private ViewBookTableAdapter ViewBookTableAdapter
        {
            get
            {
                if (_viewBookTableAdapter == null)
                {
                    _viewBookTableAdapter = new ViewBookTableAdapter();
                    _viewBookTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewBookTableAdapter;
            }
        }

        private ViewBookAvailableTableAdapter _viewBookAvailableTableAdapter;
        private ViewBookAvailableTableAdapter ViewBookAvailableTableAdapter
        {
            get
            {
                if (_viewBookAvailableTableAdapter == null)
                {
                    _viewBookAvailableTableAdapter = new ViewBookAvailableTableAdapter();
                    _viewBookAvailableTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewBookAvailableTableAdapter;
            }
        }

        private ViewBookBorrowedTableAdapter _viewBookBorrowedTableAdapter;
        private ViewBookBorrowedTableAdapter ViewBookBorrowedTableAdapter
        {
            get
            {
                if (_viewBookBorrowedTableAdapter == null)
                {
                    _viewBookBorrowedTableAdapter = new ViewBookBorrowedTableAdapter();
                    _viewBookBorrowedTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewBookBorrowedTableAdapter;
            }
        }

        #endregion

        public BookEntity GetByISBN(string isbn)
        {
            var table = ViewBookTableAdapter.GetDataByISBN(isbn);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>().FirstOrDefault();
        }
        public List<BookEntity> GetAll()
        {
            var table = ViewBookTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }
        public List<BookEntity> Search(BookSearchCriteriaDto dto)
        {
            var table = ViewBookTableAdapter.GetDataBySearchCriterias(dto.BookName, dto.AuthorName, dto.CategoryId ?? 0);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }

        public List<BookEntity> GetAllBookBorrowed()
        {
            var table = ViewBookBorrowedTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }

        public List<BookEntity> GetAllBookAvailable()
        {
            var table = ViewBookAvailableTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>();
        }

        public string Add(BookEntity book)
        {
            var id = TabBookTableAdapter.InsertCustom(book.ISBN, book.BookName, book.Author, book.Category, book.Language, book.PublishYear, book.Pages, book.Publisher);
            return 0 < id ? book.ISBN : "";
        }

        public bool Update(BookEntity book)
        {
            return 0 < TabBookTableAdapter.UpdateById(book.BookName, book.Author, book.Category, book.Language, book.PublishYear, book.Pages, book.Publisher, book.ISBN);
        }

        public bool Delete(string isbn)
        {
            return 0 < TabBookTableAdapter.DeleteByISBN(isbn);
        }

        public BookEntity GetAvailableBookByISBN(string isbn)
        {
            var table = ViewBookAvailableTableAdapter.GetByISBN(isbn);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>().FirstOrDefault();
        }

        public BookEntity GetBorrowedBookByUserIdAndISBN(int userId, string isbn)
        {
            var table = ViewBookBorrowedTableAdapter.GetByUserIdAndISBN(userId, isbn);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BookEntity>().FirstOrDefault();
        }
    }
}
