using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class LanguageCreateDto
    {

        [Required, StringLength(50)]
        public string LanguageName { get; set; }
    }
}
