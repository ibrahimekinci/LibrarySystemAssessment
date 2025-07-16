using LibrarySystem.DAL.DataSets.BarrowDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
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
            var id = tableAdapter.InsertCustom(borrow.UID,borrow.ISBN,formatDateForDb(borrow.BorrowDate), formatDateForDb(borrow.ReturnDate));
            return id;
        }

        public List<BarrowEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = Mapper.Map<List<BarrowEntity>>(table) ?? new List<BarrowEntity>();
            return result;
        }

        public List<BarrowEntity> GetAllByUserId(int uid)
        {
            var table = tableAdapter.GetByUserId(uid);
            var result = Mapper.Map<List<BarrowEntity>>(table) ?? new List<BarrowEntity>();
            return result;
        }

        public BarrowEntity GetById(int bid)
        {
            var table = tableAdapter.GetById(bid);
            var row = table.FirstOrDefault();
            return row == null ? new BarrowEntity() : Mapper.Map<BarrowEntity>(row);
        }

        public bool Return(int borrowId, DateTime actualReturnDate, decimal lateFee)
        {
            return tableAdapter.UpdateActualReturn(formatDateForDb(actualReturnDate), lateFee, borrowId) > 0;
        }
    }
}
