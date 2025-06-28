namespace LibrarySystem.Domain.Entities
{
    public class Book
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public int PublishYear { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
    }
}
