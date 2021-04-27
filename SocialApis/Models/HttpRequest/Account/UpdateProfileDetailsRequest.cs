using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Models.HttpRequest.Account
{
    public class UpdateProfileDetailsRequest
    {
        public string JwtToken { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CountryCode { get; set; }
        public int? GenderId { get; set; }
    }
}
