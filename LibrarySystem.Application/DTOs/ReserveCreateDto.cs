using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BLL.DTOs
{
    public class ReserveCreateDto
    {

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReservedDate { get; set; }
    }
}
