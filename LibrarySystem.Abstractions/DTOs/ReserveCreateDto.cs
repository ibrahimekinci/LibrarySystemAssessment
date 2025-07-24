using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Abstractions.DTOs
{
    public class ReserveCreateDto
    {
        [Required]
        public int UID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReservedDate { get; set; }
    }
}
