using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class BarrowRecordUpdateDto
    {
        [Required]
        public int BID { get; set; }
        [Required]
        public DateTime ActualReturnDate { get; set; }
        [Required]
        public decimal LateFee { get; set; }
    }
}
