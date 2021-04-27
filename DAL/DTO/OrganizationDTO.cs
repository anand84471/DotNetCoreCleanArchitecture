using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class OrganizationDTO: TimelineDTO
    {
        public long OrganizationId { get; set; }
        public string Name { get; set; }
    }
}
