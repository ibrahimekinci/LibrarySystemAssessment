using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class ReserveUpdateDto
    {
        [Required]
        public int RID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReservedDate { get; set; }
    }
}
