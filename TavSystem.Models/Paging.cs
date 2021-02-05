using System;
using System.Collections.Generic;
using System.Text;

namespace TavSystem.Models
{
    public class Paging
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Total { get; set; }
    }
}
