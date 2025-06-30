using LibrarySystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class UserUpdateDto
    {

        [Required]
        public int UID { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression(@"^(\+614|04)\d{8}$", ErrorMessage = "Invalid Australian phone number.")]
        public string Phone { get; set; }

        [Required]
        public UserLevelEnum UserLevel { get; set; }
    }
}