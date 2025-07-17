using LibrarySystem.DAL.DataSets.UserDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TabUserTableAdapter tableAdapter = new TabUserTableAdapter();

        public int Add(UserEntity user)
        {
            var effectedDbRows = tableAdapter.InsertCustom(user.UserName, user.Password, user.Phone, user.Email, (int)user.UserLevel);
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
            return tableAdapter.GetData().ToList<UserEntity>();
        }

        public UserEntity GetById(int uid)
        {
            return tableAdapter.GetById(uid).ToList<UserEntity>().FirstOrDefault();
        }

        public UserEntity GetByUsername(string username)
        {
            return tableAdapter.GetByUserName(username).ToList<UserEntity>().FirstOrDefault();
        }
        public bool Update(UserEntity user)
        {
            return 0 < tableAdapter.UpdateById(user.UserName, user.Password, user.Phone, user.Email, (int)user.UserLevel, user.UID);
        }
    }
}
