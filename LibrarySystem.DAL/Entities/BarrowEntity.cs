using System;

namespace LibrarySystem.DAL.Entities
{
    public class BarrowEntity
    {
        public int BID { get; set; }
        public string ISBN { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public decimal LateFee { get; set; }
        public DateTime BorrowDate { get; set; }

        public string BookName { get; set; }
    }
}
