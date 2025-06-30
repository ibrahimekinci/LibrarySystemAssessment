using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class CategoryCreateDto
    {
        [Required, StringLength(50)]
        public string CategoryName { get; set; }
    }
}
