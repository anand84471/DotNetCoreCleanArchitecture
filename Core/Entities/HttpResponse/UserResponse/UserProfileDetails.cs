using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.HttpResponse.UserResponse
{
    public class UserProfileDetails
    {
        public string FullName { get; set; }
        public int? CountryCode { get; set; }

        public int? GenderId { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
