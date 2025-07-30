using LibrarySystem.Abstractions.DTOs;

namespace LibrarySystem.Abstractions.Services
{
    public interface  IAuthenticationService
    {
        AuthenticatedUserDto Login(string username, string password);
    }
}
