namespace LibrarySystem.Domain.Entities
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserLevel { get; set; }
        public string UserLevelName
        {
            get
            {
                if (1 == UserLevel) return "Student";
                else if (2 == UserLevel) return "Staff";
                else if (3 == UserLevel) return "Manager";
                else return "Unknown";
            }
        }
    }
}