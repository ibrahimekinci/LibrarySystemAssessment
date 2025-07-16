using LibrarySystem.DAL.DataSets.BookDataSetTableAdapters;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System;
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
            var table = ViewAdapter.GetData().AsEnumerable()
                .Where(r => r.Field<string>("ISBN") == isbn)
                .CopyToDataTable();

            if (table.Rows.Count == 0) return null;

            return Mapper.Map<BookEntity>(table.Rows[0]);
        }
        public List<BookEntity> GetAll()
        {
            var table = ViewAdapter.GetData();
            var result = Mapper.Map<List<BookEntity>>(table) ?? new List<BookEntity>();
            return result;
        }
        public List<BookEntity> Search(BookSearchCriteriaDto dto)
        {
            var table = ViewAdapter.GetData();
            var filtered = table.AsEnumerable();

            if (filtered.Count() > 0 && !string.IsNullOrWhiteSpace(dto.BookName))
                filtered = filtered.Where(r => r.Field<string>("BookName").IndexOf(dto.BookName, StringComparison.OrdinalIgnoreCase) >= 0);

            if (filtered.Count() > 0 && !string.IsNullOrWhiteSpace(dto.AuthorName))
                filtered = filtered.Where(r => r.Field<string>("AuthorName").IndexOf(dto.AuthorName, StringComparison.OrdinalIgnoreCase) >= 0);

            if (filtered.Count() > 0 && dto.CategoryId.HasValue && dto.CategoryId > 0)
                filtered = filtered.Where(r => r.Field<int>("Category") == dto.CategoryId);


            List<BookEntity> result = null;

            if (filtered.Count() > 0)
                result = Mapper.Map<List<BookEntity>>(filtered);

            if (result == null)
                result = new List<BookEntity>();

            return result;
        }

        public List<BookEntity> GetAllBookBorrowed()
        {
            var table = _viewBookBorrowedAdapter.GetData();
            var result = Mapper.Map<List<BookEntity>>(table) ?? new List<BookEntity>();
            return result;
        }

        public List<BookEntity> GetAllBookAvailable()
        {
            var table = _viewBookAvailableAdapter.GetData();
            var result = Mapper.Map<List<BookEntity>>(table) ?? new List<BookEntity>();
            return result;
        }

        public string Add(BookEntity book)
        {
            var id = tableAdapter.InsertCustom(book.ISBN, book.BookName, book.Author, book.Category, book.Language, book.PublishYear, book.Pages, book.Publisher);
            return id > 0 ? book.ISBN : "";
        }

        public bool Update(BookEntity book)
        {
            return tableAdapter.UpdateById(book.BookName, book.Author, book.Category, book.Language, book.PublishYear, book.Pages, book.Publisher, book.ISBN) > 0;
        }

        public bool Delete(string isbn)
        {
            return tableAdapter.DeleteByISBN(isbn) > 0;
        }
    }
}
