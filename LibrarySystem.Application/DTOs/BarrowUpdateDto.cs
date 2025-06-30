using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class BarrowUpdateDto
    {
        [Required]
        public int BID { get; set; }
        [Required]
        public DateTime ActualReturnDate { get; set; }
        [Required]
        public decimal LateFee { get; set; }
    }
}
