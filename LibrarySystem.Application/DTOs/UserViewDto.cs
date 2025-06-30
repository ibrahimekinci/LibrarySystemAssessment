using LibrarySystem.Domain.Enums;

namespace LibrarySystem.BLL.DTOs
{
    public class UserViewDto
    {
        public string UserName { get; set; }
        public int UID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserLevelEnum UserLevel { get; set; }
        public string UserLevelName
        {
            get
            {
                if (UserLevelEnum.Student == UserLevel) return "Student";
                else if (UserLevelEnum.Staff == UserLevel) return "Staff";
                else if (UserLevelEnum.Manager == UserLevel) return "Manager";
                else return "Unknown";
            }
        }
    }
}