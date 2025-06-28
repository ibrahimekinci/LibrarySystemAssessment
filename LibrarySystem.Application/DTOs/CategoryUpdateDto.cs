using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        public int CID { get; set; }
        [Required, StringLength(50)]
        public string CategoryName { get; set; }
    }
}
