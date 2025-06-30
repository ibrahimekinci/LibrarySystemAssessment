using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Interfaces;
using LibrarySystem.DAL.Repositories;

namespace LibrarySystem.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _repository = new UserRepository();
        public UserViewDto Authenticate(string username, string password)
        {
            UserViewDto result = null;
            var user = _repository.GetByUsername(username);

            if (user.UID > 0 && user.Password == password)
            {
                result = Mapper.Map<UserViewDto>(user);
            }
            else
            {
                result = new UserViewDto();
            }

            return result;
        }

        public PagedResultDto<UserViewDto> GetAllUsers(PagedRequestDto pagedRequestDto)
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
