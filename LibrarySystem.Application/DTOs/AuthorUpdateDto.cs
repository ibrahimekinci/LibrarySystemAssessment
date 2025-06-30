using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class AuthorUpdateDto
    {
        [Required]
        public int AID { get; set; }

        [Required, StringLength(100)]
        public string AuthorName { get; set; }
    }
}
