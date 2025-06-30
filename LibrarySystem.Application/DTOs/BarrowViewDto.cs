using System;

namespace LibrarySystem.BLL.DTOs
{
    public class BarrowViewDto
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
