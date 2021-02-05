using System;
using System.ComponentModel.DataAnnotations;

namespace TavSystem.Models
{
    public class InvitemInfoDto
    {
        [Required]
        public string InvitemNo { get; set; }
        [Required]
        public DateTimeOffset InvitemDate { get; set; }
        [Required]
        public long CustomerId { get; set; }

        [Required]
        public int Count { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public long ProductId { get; set; }
    }
}
