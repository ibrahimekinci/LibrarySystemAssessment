using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Interfaces;

namespace LibrarySystem.Application.Services
{
    public class UserService : IUserService
    {
        public UserViewDto Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<UserViewDto> GetAllUsers(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public UserViewDto GetById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public int Register(UserCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void ResetPassword(UserPasswordUpdateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(UserUpdateDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
