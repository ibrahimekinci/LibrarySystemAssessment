using System;

namespace LibrarySystem.Domain.Entities
{
    public class BorrowRecord
    {
        public int BID { get; set; }
        public int UID { get; set; }
        public string ISBN { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public decimal LateFee { get; set; }
    }
}
