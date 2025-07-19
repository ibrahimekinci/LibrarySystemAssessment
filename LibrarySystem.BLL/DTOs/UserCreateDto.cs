using LibrarySystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class UserCreateDto
    {

        [Required, StringLength(8)]
        public string UserName { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression(@"^(\+614|04)\d{8}$", ErrorMessage = "Invalid Australian phone number.")]
        public string PhoneNumber { get; set; }
      
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserLevel selection is required.")]
        public UserLevelEnum UserLevel { get; set; }
    }
}
