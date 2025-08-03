using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Abstractions.DTOs
{
    public class BookDto
    {
        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required, StringLength(100)]
        public string BookName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Author selection is required.")]
        public int Author { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Category selection is required.")]
        public int Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Language selection is required.")]
        public int Language { get; set; }

        [Range(1800, 2100)]
        public int PublishYear { get; set; }

        [Range(1, int.MaxValue)]
        public int Pages { get; set; }

        [Required, StringLength(100)]
        public string Publisher { get; set; }
    }
}
