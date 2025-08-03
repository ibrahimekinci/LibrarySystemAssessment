using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Helpers;

namespace LibrarySystem.BLL.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticatedUserDto Login(string username, string password)
        {
            var user = UserRepository.GetByUsername(username);
            if (user == null || user.UID < 1 || user.Password != password)
                return null;

            var result = Mapper.Map<AuthenticatedUserDto>(user);
            result.Token = JwtHelper.GenerateToken(result);
            return result;
        }

        public AuthenticatedUserDto RefreshToken(int uid)
        {
            var user = UserRepository.GetById(uid);
            if (user == null || user.UID < 1)
                return null;

            var result = Mapper.Map<AuthenticatedUserDto>(user);
            result.Token = JwtHelper.GenerateToken(result);
            return result;
        }
    }
}