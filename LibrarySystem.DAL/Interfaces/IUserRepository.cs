using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IUserRepository
    {
        UserEntity GetById(int uid);
        UserEntity GetByUsername(string username);
        PagedResultDto<List<UserEntity>> GetAllPaged(PagedRequestDto request);
        int Add(UserEntity user);
        void Update(UserEntity user);
        void UpdatePassword(int uid, string hashedPassword);
    }
}
