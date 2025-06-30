using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class PagedRequestDto
    {
        public PagedRequestDto()
        {
            PageNumber = 1;
            PageSize = int.MaxValue;
        }
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
    }
}
