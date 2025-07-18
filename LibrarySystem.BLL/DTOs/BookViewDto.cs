using System.ComponentModel;

namespace LibrarySystem.BLL.DTOs
{
    public class BookViewDto
    {
        public string ISBN { get; set; }
        [DisplayName("Book Name")]
        public string BookName { get; set; }
        [DisplayName("Publish Year")]
        public int PublishYear { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }

        public int Author { get; set; }
        public int Category { get; set; }
        public int Language { get; set; }
        [DisplayName("Author")]
        public string AuthorName { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        [DisplayName("Language")]
        public string LanguageName { get; set; }
    }
}
