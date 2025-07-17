using LibrarySystem.DAL.DataSets.BarrowDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class BorrowRepository : BaseRepository, IBorrowRepository
    {
        private readonly TabBorrowTableAdapter tableAdapter = new TabBorrowTableAdapter();

        public int Add(BarrowEntity borrow)
        {
            var effectedDbRows = tableAdapter.InsertCustom(borrow.UID, borrow.ISBN, borrow.BorrowDate.FormatForDb(), borrow.ReturnDate.FormatForDb());
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public List<BarrowEntity> GetAll()
        {
            return tableAdapter.GetData().ToList<BarrowEntity>();
        }

        public List<BarrowEntity> GetAllByUserId(int uid)
        {
            return tableAdapter.GetByUserId(uid).ToList<BarrowEntity>();
        }

        public BarrowEntity GetById(int bid)
        {
            return tableAdapter.GetById(bid).ToList<BarrowEntity>().FirstOrDefault();

        }

        public bool Return(int borrowId, DateTime actualReturnDate, decimal lateFee)
        {
            return 0 < tableAdapter.UpdateActualReturn(actualReturnDate.FormatForDb(), lateFee, borrowId);
        }
    }
}
