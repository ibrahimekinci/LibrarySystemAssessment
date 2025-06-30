using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class UserPasswordUpdateDto
    {
        [Required]
        public int UID { get; set; }

        [StringLength(30, MinimumLength = 6)]
        [Required]
        public string NewPassword { get; set; }
    }
}
