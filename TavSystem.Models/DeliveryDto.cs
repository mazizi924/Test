using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TavSystem.Models
{
    public class DeliveryDto
    {
        [Required] 
        public string DeliveryNo { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public long ProductId { get; set; }
    }
}
