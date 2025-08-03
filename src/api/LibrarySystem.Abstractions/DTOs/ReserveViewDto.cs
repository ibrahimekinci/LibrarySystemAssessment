using System;

namespace LibrarySystem.Abstractions.DTOs
{
    public class ReserveViewDto
    {
        public int RID { get; set; }
        public string ISBN { get; set; }
        public DateTime ReservedDate { get; set; }
        public string BookName { get; set; }
    }
}
