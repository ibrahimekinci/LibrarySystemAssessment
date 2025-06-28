using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class LanguageUpdateDto
    {
        [Required]
        public int LID { get; set; }

        [Required, StringLength(50)]
        public string LanguageName { get; set; }
    }
}
