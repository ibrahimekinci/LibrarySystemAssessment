using LibrarySystem.DAL.DataSets.ReserveDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Repositories
{
    public class ReserveRepository : BaseRepository, IReserveRepository
    {
        private readonly TabReservedTableAdapter tableAdapter = new TabReservedTableAdapter();
        public int Add(ReserveEntity reserve)
        {
            var effectedDbRows = tableAdapter.InsertCustom(reserve.UID, reserve.ISBN, formatDateForDb(reserve.ReservedDate));
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int rid)
        {
            return tableAdapter.DeleteById(rid) > 0;
        }

        public List<ReserveEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = Mapper.Map<List<ReserveEntity>>(table) ?? new List<ReserveEntity>();
            return result;
        }

        public List<ReserveEntity> GetByUserId(int uid)
        {
            var table = tableAdapter.GetByUserId(uid);
            var result = Mapper.Map<List<ReserveEntity>>(table) ?? new List<ReserveEntity>();
            return result;
        }
    }
}
