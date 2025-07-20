using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IUserRepository
    {
        //PagedResultDto<List<UserEntity>> GetAllPaged(PagedRequestDto request);
        List<UserEntity> GetAll();
        UserEntity GetById(int uid);
        UserEntity GetByUsername(string username);
        int Add(UserEntity user);
        bool Delete(int uid);
        bool Update(UserEntity user);
        bool UpdatePasswordByUserId(int userId, string password);
    }
}
