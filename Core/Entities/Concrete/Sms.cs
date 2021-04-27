using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Sms
    {
        public string PhoneNo { get; set; }
        public string Message { get; set; }
        public string CountryCode { get; set; }
    }
}
