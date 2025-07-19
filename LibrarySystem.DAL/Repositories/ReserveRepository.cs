using LibrarySystem.DAL.DataSets.ReserveDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class ReserveRepository : BaseRepository, IReserveRepository
    {
        private readonly TabReservedTableAdapter tableAdapter = new TabReservedTableAdapter();
        private readonly ViewReservationsTableAdapter viewAdapter = new ViewReservationsTableAdapter();
        public int Add(ReserveEntity reserve)
        {
            var effectedDbRows = tableAdapter.InsertCustom(reserve.UID, reserve.ISBN, reserve.ReservedDate.FormatForDb());
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int rid)
        {
            return 0 < tableAdapter.DeleteById(rid);
        }

        public DataTable GetAll()
        {
            var table = viewAdapter.GetAll();
            return table;
        }

        public DataTable GetAllByUserId(int userId)
        {
            var table = viewAdapter.GetAllByUserId(userId);
            return table;
        }
        public ReserveEntity GetById(int id)
        {
            var table = tableAdapter.GetById(id);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<ReserveEntity>().FirstOrDefault();
        }

        //public List<ReserveEntity> GetByUserId(int uid)
        //{
        //    var table = tableAdapter.GetByUserId(uid);
        //    if (table == null || table.Rows.Count == 0)
        //        return null;
        //    return table.CopyToDataTable().ToList<ReserveEntity>();
        //}
    }
}
