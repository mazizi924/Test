using System;

namespace TavSystem.Models
{
    public class InvitemDetailDto
    {
        public int Count { get; set; }
        public long Price { get; set; }
        public DateTimeOffset Date { get; set; }
        public long InvitemId { get; set; }
        public long ProductId { get; set; }
    }
}
