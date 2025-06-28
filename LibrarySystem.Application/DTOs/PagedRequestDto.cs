using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class PagedRequestDto
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
    }
}
