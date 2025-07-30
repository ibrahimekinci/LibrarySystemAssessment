using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Services
{
    public interface IUserService
    {
        int Register(UserCreateDto dto); // Used by Manager to add Staff or Student
        bool UpdateUser(UserUpdateDto dto);
        bool ResetPassword(UserPasswordUpdateDto dto); // Manager can reset password
        List<UserViewDto> GetAll();
        UserViewDto GetById(int userId);
        bool Delete(int userId);
    }
}
