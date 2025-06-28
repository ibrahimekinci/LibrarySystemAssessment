using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class AuthorCreateDto
    {

        [Required, StringLength(100)]
        public string AuthorName { get; set; }
    }
}
