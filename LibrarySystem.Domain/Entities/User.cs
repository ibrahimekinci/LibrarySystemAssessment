using LibrarySystem.Domain.Enums;

namespace LibrarySystem.Domain.Entities
{
    public class User
    {
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserLevelEnum UserLevel { get; set; } // Enum-based role
    }
}
