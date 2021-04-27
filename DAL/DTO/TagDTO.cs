using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class TagDTO:TimelineDTO
    {
        public long TagId { get; set; }
        public string Name { get; set; }
    }
}
