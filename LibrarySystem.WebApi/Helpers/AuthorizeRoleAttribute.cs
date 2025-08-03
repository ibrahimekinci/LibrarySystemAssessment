using LibrarySystem.Abstractions.Enums;
using System;

namespace LibrarySystem.WebApi.Helpers
{
    // Custom attribute for role-based authorization
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeRoleAttribute : Attribute
    {
        public UserLevelEnum[] AllowedRoles { get; }
        public AuthorizeRoleAttribute(params UserLevelEnum[] allowedRoles)
        {
            AllowedRoles = allowedRoles;
        }
        public AuthorizeRoleAttribute(UserLevelEnum allowedRole)
        {
            AllowedRoles = new UserLevelEnum[] { allowedRole };
        }
    }
}