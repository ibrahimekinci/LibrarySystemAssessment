using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class BarrowCreateDto
    {

        [Required]
        public int UID { get; set; }

        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }
    }
}
