using LibrarySystem.BLL.DTOs;
using LibrarySystem.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.App.Helpers
{
    public static class UserManager
    {
        public static UserViewDto CurrentUser { get; set; }
        public static bool IsUserAuthorized(IReadOnlyList<UserLevelEnum> allowedUserLevels)
        {
            return CurrentUser != null && allowedUserLevels.Contains(CurrentUser.UserLevel);
        }
        public static bool IsUserLoggedIn()
        {
            return CurrentUser != null && CurrentUser.UID > 0;
        }
        public static bool IsloggedInAsManager()
        {
            return IsUserLoggedIn() && CurrentUser.UserLevel == UserLevelEnum.Manager;
        }

        public static bool IsloggedInAsStaff()
        {
            return IsUserLoggedIn() && CurrentUser.UserLevel == UserLevelEnum.Staff;
        }

        public static bool IsloggedInAsStudent()
        {
            return IsUserLoggedIn() && CurrentUser.UserLevel == UserLevelEnum.Student;
        }
    }
}
