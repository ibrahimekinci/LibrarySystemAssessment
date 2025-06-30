using System;
using System.Collections.Generic;

namespace LibrarySystem.BLL.DTOs
{
    public class PagedResultDto<T>
    {
        public T Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
