using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Organization:Timeline
    {
        public long OrganizationId { get; set; }
        public string name { get; set; }
    }
}
