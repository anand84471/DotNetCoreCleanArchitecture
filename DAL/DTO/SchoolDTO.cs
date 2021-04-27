using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class SchoolDTO: TimelineDTO
    {
        public long SchoolId { get; set; }
        public string Name { get; set; }
    }
}
