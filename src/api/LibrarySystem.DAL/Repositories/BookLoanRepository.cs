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
        #region TableAdapter Properties

        private TabBorrowTableAdapter _tabBorrowTableAdapter;
        private TabBorrowTableAdapter TabBorrowTableAdapter
        {
            get
            {
                if (_tabBorrowTableAdapter == null)
                {
                    _tabBorrowTableAdapter = new TabBorrowTableAdapter();
                    _tabBorrowTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabBorrowTableAdapter;
            }
        }

        private ViewBookLoansTableAdapter _viewBookLoansTableAdapter;
        private ViewBookLoansTableAdapter ViewBookLoansTableAdapter
        {
            get
            {
                if (_viewBookLoansTableAdapter == null)
                {
                    _viewBookLoansTableAdapter = new ViewBookLoansTableAdapter();
                    _viewBookLoansTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewBookLoansTableAdapter;
            }
        }

        #endregion

        public int Add(BorrowEntity borrow)
        {
            var effectedDbRows = TabBorrowTableAdapter.InsertCustom(borrow.UID, borrow.ISBN, borrow.BorrowDate.FormatForDb(), borrow.ReturnDate.FormatForDb());
            if (effectedDbRows <= 0)
                return 0;
            var id = Convert.ToInt32(TabBorrowTableAdapter.GetLastId());
            return id;
        }

        public List<BorrowEntity> GetAll()
        {
            var table = TabBorrowTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BorrowEntity>();
        }

        public List<BorrowEntity> GetAllByUserId(int uid)
        {
            var table = TabBorrowTableAdapter.GetByUserId(uid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BorrowEntity>();
        }

        public BorrowEntity GetById(int bid)
        {
            var table = TabBorrowTableAdapter.GetById(bid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BorrowEntity>().FirstOrDefault();

        }

        public bool Return(int borrowId, DateTime actualReturnDate, decimal lateFee)
        {
            return 0 < TabBorrowTableAdapter.ReturnBook(actualReturnDate.FormatForDb(), lateFee, borrowId);
        }

        public bool Delete(int bid)
        {
            return 0 < TabBorrowTableAdapter.DeleteById(bid);
        }

        public DataTable GetUnreturnedLoansByUserId(int UID)
        {
            return ViewBookLoansTableAdapter.GetUnReturnedBooks(UID);
        }

        public DataTable GetAllLoans()
        {
            return ViewBookLoansTableAdapter.GetAll();
        }

        public DataTable GetLoansByUserId(int uid)
        {
            return ViewBookLoansTableAdapter.GetLoansByUserId(uid);
        }
    }
}
