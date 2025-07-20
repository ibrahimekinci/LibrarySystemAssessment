using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IUserService
    {
        UserViewDto Authenticate(string username, string password);
        int Register(UserCreateDto dto); // Used by Manager to add Staff or Student
        bool UpdateUser(UserUpdateDto dto);
        bool ResetPassword(UserPasswordUpdateDto dto); // Manager can reset password
        List<UserViewDto> GetAll();
        UserViewDto GetById(int userId);
        bool Delete(int userId);
    }
}
