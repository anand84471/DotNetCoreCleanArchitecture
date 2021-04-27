using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Models.HttpRequest.UserAccountManagement
{
    public class UserAccountDetailsUpdateRequest
    {
        [Display(Name = "user_id")]
        public long UserId { get; set; }
        [Required]
        [Display(Name = "country_code")]
        public int? CountryCode { get; set; }
        [Required]
        [Display(Name = "gender_id")]
        public int? GenderId { get; set; }
        [Required]
        [Display(Name = "date_of_birth")]
        public DateTime? DateOfBirth { get; set; }
    }
}
