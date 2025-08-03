using LibrarySystem.Abstractions.DTOs;

namespace LibrarySystem.Abstractions.Services
{
    public interface  IAuthenticationService
    {
        AuthenticatedUserDto RefreshToken(int uid);
        AuthenticatedUserDto Login(string username, string password);
    }
}
