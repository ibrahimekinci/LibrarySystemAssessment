using LibrarySystem.DAL.DataSets.UserDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
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
            return tableAdapter.DeleteById(uid) > 0;
        }

        public List<UserEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = Mapper.Map<List<UserEntity>>(table) ?? new List<UserEntity>();
            return result;
        }

        public UserEntity GetById(int uid)
        {
            var table = tableAdapter.GetById(uid);
            var row = table.FirstOrDefault();
            return row == null ? new UserEntity() : Mapper.Map<UserEntity>(row);
        }

        public UserEntity GetByUsername(string username)
        {
            var table = tableAdapter.GetByUserName(username);
            var row = table.FirstOrDefault();
            var result = row == null ? new UserEntity() : Mapper.Map<UserEntity>(row);
            return result;
        }
        public bool Update(UserEntity user)
        {
            return tableAdapter.UpdateById(user.UserName, user.Password, user.Phone, user.Email, (int)user.UserLevel, user.UID) > 0;
        }
    }
}
