using LibrarySystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class UserCreateDto
    {

        [Required, StringLength(8)]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression(@"^(\+614|04)\d{8}$", ErrorMessage = "Invalid Australian phone number.")]
        public string Phone { get; set; }
      
        [Required]
        public UserLevelEnum UserLevel { get; set; }
    }
}
