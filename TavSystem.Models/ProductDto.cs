using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TavSystem.Models
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public int MinInventory { get; set; }
        [Required]
        public long CategoryId { get; set; }
    }
}
