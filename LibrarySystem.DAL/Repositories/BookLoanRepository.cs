using LibrarySystem.Abstractions.Repositories;
using LibrarySystem.DAL.DataSets.BorrowDataSetTableAdapters;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class BookLoanRepository : BaseRepository, IBookLoanRepository
    {
        private readonly TabBorrowTableAdapter tableAdapter = new TabBorrowTableAdapter();
        private readonly ViewBookLoansTableAdapter viewAdapter = new ViewBookLoansTableAdapter();

        public int Add(BorrowEntity borrow)
        {
            var effectedDbRows = tableAdapter.InsertCustom(borrow.UID, borrow.ISBN, borrow.BorrowDate.FormatForDb(), borrow.ReturnDate.FormatForDb());
            if (effectedDbRows <= 0)
                return 0;
            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public List<BorrowEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BorrowEntity>();
        }

        public List<BorrowEntity> GetAllByUserId(int uid)
        {
            var table = tableAdapter.GetByUserId(uid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BorrowEntity>();
        }

        public BorrowEntity GetById(int bid)
        {
            var table = tableAdapter.GetById(bid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BorrowEntity>().FirstOrDefault();

        }

        public bool Return(int borrowId, DateTime actualReturnDate, decimal lateFee)
        {
            return 0 < tableAdapter.ReturnBook(actualReturnDate.FormatForDb(), lateFee, borrowId);
        }

        public bool Delete(int bid)
        {
            return 0 < tableAdapter.DeleteById(bid);
        }

        public DataTable GetUnreturnedLoansByUserId(int UID)
        {
            return viewAdapter.GetUnReturnedBooks(UID);
        }

        public DataTable GetAllLoans()
        {
            return viewAdapter.GetAll();
        }

        public DataTable GetLoansByUserId(int uid)
        {
            return viewAdapter.GetLoansByUserId(uid);
        }
    }
}
