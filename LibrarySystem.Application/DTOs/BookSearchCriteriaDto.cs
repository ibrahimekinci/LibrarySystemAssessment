namespace LibrarySystem.Application.DTOs
{
    public class BookSearchCriteriaDto
    {
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int? LanguageId { get; set; }
    }
}
