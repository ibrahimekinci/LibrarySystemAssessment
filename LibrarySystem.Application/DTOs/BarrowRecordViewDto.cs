using System;

namespace LibrarySystem.Application.DTOs
{
    public class BarrowRecordViewDto
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
