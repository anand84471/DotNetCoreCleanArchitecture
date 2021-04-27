using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Tag:Timeline
    {
        public long TagId { get; set; }
        public string Name { get; set; }
    }
}
