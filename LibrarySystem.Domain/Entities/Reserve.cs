using System;

namespace LibrarySystem.Domain.Entities
{
    public class Reserve
    {
        public int RID { get; set; }
        public int UID { get; set; }
        public string ISBN { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}
