using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class CategoryCreateDto
    {
        [Required, StringLength(50)]
        public string CategoryName { get; set; }
    }
}
