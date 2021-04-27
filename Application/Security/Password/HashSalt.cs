using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Security.Password
{
    public class HashSalt
    {
        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
