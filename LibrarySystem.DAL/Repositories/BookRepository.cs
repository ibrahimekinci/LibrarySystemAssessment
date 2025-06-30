// BookRepository.cs — Implementation using XSD and AutoMapper
using System.Data;
using System.Linq;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using LibrarySystem.DAL.DataSets.BookDataSetTableAdapters;
using System.Collections.Generic;
using System;

namespace LibrarySystem.DAL.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        private readonly ViewBookTableAdapter _viewBookAdapter = new ViewBookTableAdapter();
        private readonly TabBookTableAdapter _tabBookAdapter = new TabBookTableAdapter();

        public BookEntity GetByISBN(string isbn)
        {
            var table = _viewBookAdapter.GetData().AsEnumerable()
                .Where(r => r.Field<string>("ISBN") == isbn)
                .CopyToDataTable();

            if (table.Rows.Count == 0) return null;

            return Mapper.Map<BookEntity>(table.Rows[0]);
        }
        public List<BookEntity> GetAll()
        {
            var table = _viewBookAdapter.GetData();
            var result = Mapper.Map<List<BookEntity>>(table) ?? new List<BookEntity>();
            return result;
        }
        public List<BookEntity> Search(BookSearchCriteriaDto dto)
        {
            var table = _viewBookAdapter.GetData();
            var filtered = table.AsEnumerable();

            if (filtered.Count() > 0 && !string.IsNullOrWhiteSpace(dto.BookName))
                filtered = filtered.Where(r => r.Field<string>("BookName").IndexOf(dto.BookName, StringComparison.CurrentCultureIgnoreCase) > 0);

            if (filtered.Count() > 0 && !string.IsNullOrWhiteSpace(dto.AuthorName))
                filtered = filtered.Where(r => r.Field<string>("AuthorName").IndexOf(dto.AuthorName, StringComparison.CurrentCultureIgnoreCase) > 0);

            if (filtered.Count() > 0 && dto.CategoryId.HasValue && dto.CategoryId > 0)
                filtered = filtered.Where(r => r.Field<int>("Category") == dto.CategoryId);


            List<BookEntity> result = null;

            if (filtered.Count() > 0)
                result = Mapper.Map<List<BookEntity>>(filtered);

            if (result == null)
                result = new List<BookEntity>();

            return result;
        }


        public void Update(BookEntity book)
        {
            throw new System.NotImplementedException();
        }

        public int Add(BookEntity book)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string isbn)
        {
            throw new System.NotImplementedException();
        }


    }
}
