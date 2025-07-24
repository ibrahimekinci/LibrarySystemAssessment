namespace LibrarySystem.Abstractions.DTOs
{
    public class BookSearchCriteriaDto
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int? CategoryId { get; set; }
    }
}
