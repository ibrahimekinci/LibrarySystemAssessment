using LibrarySystem.DAL.DataSets;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.DTOs;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.DAL.DataSets.UserDataSetTableAdapters;
using LibrarySystem.DAL.Interfaces;
using System.Data;

namespace LibrarySystem.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TabUserTableAdapter _adapter = new TabUserTableAdapter();

        public UserEntity GetById(int uid)
        {
            var table = _adapter.GetDataById(uid); // View ya da sorgu: WHERE UID = @uid
            var row = table.FirstOrDefault();
            return row == null ? new UserEntity() : Mapper.Map<UserEntity>(row);
        }

        public UserEntity GetByUsername(string username)
        {
            var table = _adapter.GetDataByUserName(username); // WHERE UserName = @username
            var row = table.FirstOrDefault();
            var result = row == null ? new UserEntity() : Mapper.Map<UserEntity>(row);
            return result;
        }

        public PagedResultDto<List<UserEntity>> GetAll(PagedRequestDto request)
        {
            var table = _adapter.GetData();
            var data = Mapper.Map<List<UserEntity>>(table);
            var paged = data.Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToList();

            return new PagedResultDto<List<UserEntity>>
            {
                Items = paged,
                TotalCount = data.Count,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        public PagedResultDto<List<UserEntity>> GetAllPaged(PagedRequestDto request)
        {
            throw new System.NotImplementedException();
        }

        public int Add(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePassword(int uid, string hashedPassword)
        {
            throw new System.NotImplementedException();
        }
    }
}
