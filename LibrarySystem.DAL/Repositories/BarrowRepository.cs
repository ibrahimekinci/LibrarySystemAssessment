using LibrarySystem.DAL.DataSets.BarrowDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class BarrowRepository : BaseRepository, IBarrowRepository
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
            var table = tableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BarrowEntity>();
        }

        public List<BarrowEntity> GetAllByUserId(int uid)
        {
            var table = tableAdapter.GetByUserId(uid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BarrowEntity>();
        }

        public BarrowEntity GetById(int bid)
        {
            var table = tableAdapter.GetById(bid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<BarrowEntity>().FirstOrDefault();

        }

        public bool Return(int borrowId, DateTime actualReturnDate, decimal lateFee)
        {
            return 0 < tableAdapter.UpdateActualReturn(actualReturnDate.FormatForDb(), lateFee, borrowId);
        }

        public bool Delete(int bid)
        {
            return 0 < tableAdapter.DeleteById(bid);
        }
    }
}
