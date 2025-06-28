using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class BookViewDto
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }

        public int Author { get; set; }
        public int Category { get; set; }
        public int Language { get; set; }

        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string LanguageName { get; set; }
    }
}
