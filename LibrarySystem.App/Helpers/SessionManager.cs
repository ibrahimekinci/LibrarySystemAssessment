using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.App.Helpers
{
    public static class SessionManager
    {
        private static AuthenticatedUserDto _user = null;
        public static void SetUser(AuthenticatedUserDto user)
        {
            _user = user;
        }

        public static void Clear()
        {
            _user = null;
        }

        public static AuthenticatedUserDto GetUser()
        {
            return _user;
        }

        public static bool IsUserLoggedIn()
        {
            return _user != null && _user.UID > 0;
        }

        public static bool IsUserAuthorized(IReadOnlyList<UserLevelEnum> allowedUserLevels)
        {
            return IsUserLoggedIn() && allowedUserLevels.Contains(_user.UserLevel);
        }

        public static bool IsLoggedInAs(UserLevelEnum level)
        {
            return IsUserLoggedIn() && _user.UserLevel == level;
        }

        public static bool IsLoggedInAsManager() => IsLoggedInAs(UserLevelEnum.Manager);
        public static bool IsLoggedInAsStaff() => IsLoggedInAs(UserLevelEnum.Staff);
        public static bool IsLoggedInAsStudent() => IsLoggedInAs(UserLevelEnum.Student);

        public static string UserLevelName
        {
            get
            {
                if (!IsUserLoggedIn())
                    return "Unknown";

                switch (_user.UserLevel)
                {
                    case UserLevelEnum.Student: return "Student";
                    case UserLevelEnum.Staff: return "Staff";
                    case UserLevelEnum.Manager: return "Manager";
                    default: return "Unknown";
                }
            }
        }

        public static int UID => _user?.UID ?? 0;
        public static string Username => _user?.UserName;
         public static string Token => _user?.Token;
        public static string Email => _user?.Email;
        public static string PhoneNumber => _user?.PhoneNumber;
        public static UserLevelEnum UserLevel => _user?.UserLevel ?? 0;
    }
}
