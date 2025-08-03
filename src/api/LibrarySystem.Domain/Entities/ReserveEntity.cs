using System;
namespace LibrarySystem.Domain.Entities
{
    public class ReserveEntity
    {
        public int RID { get; set; }
        public int UID { get; set; }
        public string ISBN { get; set; }
        public DateTime ReservedDate { get; set; }
        public string BookName { get; set; }
    }
}
