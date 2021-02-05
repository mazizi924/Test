using System;
using System.Collections.Generic;
using System.Text;

namespace TavSystem.Models
{
    public class InvitemDto
    {
        public string InvitemNo { get; set; }
        public DateTimeOffset InvitemDate { get; set; }
        public long CustomerId { get; set; } 
    }
}
