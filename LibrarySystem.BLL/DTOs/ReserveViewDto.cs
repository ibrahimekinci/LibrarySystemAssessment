using System;

namespace LibrarySystem.BLL.DTOs
{
    public class ReserveViewDto
    {
        public int RID { get; set; }
        public string ISBN { get; set; }
        public DateTime ReservedDate { get; set; }
        public string BookName { get; set; }
    }
}
