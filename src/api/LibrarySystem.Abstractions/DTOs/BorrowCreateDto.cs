using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Abstractions.DTOs
{
    public class BorrowCreateDto
    {

        [Required]
        public int UID { get; set; }

        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }
    }
}
