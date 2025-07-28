using LibrarySystem.Abstractions.Repositories;
using LibrarySystem.DAL.DataSets.ReserveDataSetTableAdapters;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Domain.Entities;
using System;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class ReserveRepository : BaseRepository, IReserveRepository
    {
        #region TableAdapter Properties – Reservations

        private TabReservedTableAdapter _tabReservedTableAdapter;
        private TabReservedTableAdapter TabReservedTableAdapter
        {
            get
            {
                if (_tabReservedTableAdapter == null)
                {
                    _tabReservedTableAdapter = new TabReservedTableAdapter();
                    _tabReservedTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabReservedTableAdapter;
            }
        }

        private ViewReservationsTableAdapter _viewReservationsTableAdapter;
        private ViewReservationsTableAdapter ViewReservationsTableAdapter
        {
            get
            {
                if (_viewReservationsTableAdapter == null)
                {
                    _viewReservationsTableAdapter = new ViewReservationsTableAdapter();
                    _viewReservationsTableAdapter.ApplyGlobalConfiguration();
                }
                return _viewReservationsTableAdapter;
            }
        }

        #endregion
        public int Add(ReserveEntity reserve)
        {
            var effectedDbRows = TabReservedTableAdapter.InsertCustom(reserve.UID, reserve.ISBN, reserve.ReservedDate.FormatForDb());
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(TabReservedTableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int rid)
        {
            return 0 < TabReservedTableAdapter.DeleteById(rid);
        }

        public DataTable GetAll()
        {
            var table = ViewReservationsTableAdapter.GetAll();
            return table;
        }

        public DataTable GetAllByUserId(int userId)
        {
            var table = ViewReservationsTableAdapter.GetAllByUserId(userId);
            return table;
        }
        public ReserveEntity GetById(int id)
        {
            var table = TabReservedTableAdapter.GetById(id);
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
