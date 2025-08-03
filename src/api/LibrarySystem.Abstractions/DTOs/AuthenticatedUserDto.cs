using LibrarySystem.Abstractions.Enums;

namespace LibrarySystem.Abstractions.DTOs
{
    public class AuthenticatedUserDto
    {
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserLevelEnum UserLevel { get; set; }
        public string Token { get; set; }

    }
}
