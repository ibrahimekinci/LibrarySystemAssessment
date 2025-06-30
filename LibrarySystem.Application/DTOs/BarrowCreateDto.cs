using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class BarrowCreateDto
    {
        public int BID { get; set; }

        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
