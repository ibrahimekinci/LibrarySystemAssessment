using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Helpers;

namespace LibrarySystem.BLL.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticatedUserDto Login(string username, string password)
        {
            var user = UserRepository.GetByUsername(username);
            if (user == null || user.Password != password)
                return null;

            var result = Mapper.Map<AuthenticatedUserDto>(user);
            result.Token = JwtHelper.GenerateToken(result);
            return result;
        }
    }
}