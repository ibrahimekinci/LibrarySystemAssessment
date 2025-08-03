using LibrarySystem.DAL.DataSets.UserDataSetTableAdapters;
using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region TableAdapter Properties – User

        private TabUserTableAdapter _tabUserTableAdapter;
        private TabUserTableAdapter TabUserTableAdapter
        {
            get
            {
                if (_tabUserTableAdapter == null)
                {
                    _tabUserTableAdapter = new TabUserTableAdapter();
                    _tabUserTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabUserTableAdapter;
            }
        }

        #endregion

        public int Add(UserEntity user)
        {
            var effectedDbRows = TabUserTableAdapter.InsertCustom(user.UserName, user.Password, user.PhoneNumber, user.Email, (int)user.UserLevel);
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(TabUserTableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int uid)
        {
            return 0 < TabUserTableAdapter.DeleteById(uid);
        }

        public List<UserEntity> GetAll()
        {
            var table = TabUserTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<UserEntity>();
        }

        public UserEntity GetById(int uid)
        {
            var table = TabUserTableAdapter.GetById(uid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<UserEntity>().FirstOrDefault();
        }

        public UserEntity GetByUsername(string username)
        {
            var table = TabUserTableAdapter.GetByUserName(username);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<UserEntity>().FirstOrDefault();
        }
        public bool UpdatePasswordByUserId(int userId, string password)
        {
            return 0 < TabUserTableAdapter.UpdatePasswordByUserId(password, userId);
        }
        public bool Update(UserEntity user)
        {
            return 0 < TabUserTableAdapter.UpdateById(user.UserName, user.PhoneNumber, user.Email, (int)user.UserLevel, user.UID);
        }
    }
}
