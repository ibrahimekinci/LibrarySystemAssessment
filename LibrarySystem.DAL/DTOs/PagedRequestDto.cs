namespace LibrarySystem.DAL.DTOs
{
    public class PagedRequestDto
    {
        public PagedRequestDto()
        {
            PageNumber = 1;
            PageSize = int.MaxValue;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
