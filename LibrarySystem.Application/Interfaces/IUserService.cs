using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IUserService
    {
        UserViewDto Authenticate(string username, string password);
        int Register(UserCreateDto dto); // Used by Manager to add Staff or Student
        void UpdateUser(UserUpdateDto dto); // Manager can update Email, Phone, Role
        void ResetPassword(UserPasswordUpdateDto dto); // Manager can reset password
        List<UserViewDto> GetAllUsers();
        UserViewDto GetById(int userId);
    }
}
