using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Application.Interfaces
{
    public interface IUserService
    {
        UserViewDto Authenticate(string username, string password);
        int Register(UserCreateDto dto); // Used by Manager to add Staff or Student
        void UpdateUser(UserUpdateDto dto); // Manager can update Email, Phone, Role
        void ResetPassword(UserPasswordUpdateDto dto); // Manager can reset password
        PagedResultDataTableDto<UserViewDto> GetAllUsers(PagedRequestDto pagedRequestDto);
        UserViewDto GetById(int userId);
    }
}
