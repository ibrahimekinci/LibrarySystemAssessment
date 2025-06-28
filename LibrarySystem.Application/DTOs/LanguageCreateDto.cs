using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class LanguageCreateDto
    {

        [Required, StringLength(50)]
        public string LanguageName { get; set; }
    }
}
