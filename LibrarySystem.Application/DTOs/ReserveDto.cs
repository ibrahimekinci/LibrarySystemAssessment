using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Application.DTOs
{
    public class ReserveDto
    {

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReservedDate { get; set; }
    }
}
