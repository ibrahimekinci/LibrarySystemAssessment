using LibrarySystem.DAL.DataSets.UserDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TabUserTableAdapter tableAdapter = new TabUserTableAdapter();

        public int Add(UserEntity user)
        {
            var effectedDbRows = tableAdapter.InsertCustom(user.UserName, user.Password, user.PhoneNumber, user.Email, (int)user.UserLevel);
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int uid)
        {
            return 0 < tableAdapter.DeleteById(uid);
        }

        public List<UserEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<UserEntity>();
        }

        public UserEntity GetById(int uid)
        {
            var table = tableAdapter.GetById(uid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<UserEntity>().FirstOrDefault();
        }

        public UserEntity GetByUsername(string username)
        {
            var table = tableAdapter.GetByUserName(username);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<UserEntity>().FirstOrDefault();
        }
        public bool UpdatePasswordByUserId(int userId, string password)
        {
            return 0 < tableAdapter.UpdatePasswordByUserId(password, userId);
        }
        public bool Update(UserEntity user)
        {
            return 0 < tableAdapter.UpdateById(user.UserName, user.PhoneNumber, user.Email, (int)user.UserLevel, user.UID);
        }
    }
}
