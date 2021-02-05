using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TavSystem.Models
{
    public class AccountingDocDto
    {
        [Required]
        public string DocNo { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public long InvitemId { get; set; }
    }
}
