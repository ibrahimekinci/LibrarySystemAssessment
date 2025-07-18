using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class BookDto
    {
        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required, StringLength(100)]
        public string BookName { get; set; }

        [Required]
        public int Author { get; set; }

        [Required, StringLength(50)]
        public int Category { get; set; }

        [Required]
        public int Language { get; set; }

        [Range(1800, 2100)]
        public int PublishYear { get; set; }

        [Range(1, int.MaxValue)]
        public int Pages { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }
    }
}
