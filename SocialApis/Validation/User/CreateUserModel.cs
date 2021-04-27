using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Validation.User
{
    public class CreateUserModel
    {
        [Required]
        [Display(Name = "full_name")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email_id")]
        public string EmailId { get; set; }
        [Phone]
        [Display(Name = "phone_no")]
        public string PhoneNo { get; set; }
        [Required]
        [StringLength(maximumLength: 4)]
        [Display(Name = "phone_code")]
        public string PhoneCode { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "password")]
        public string Password { get; set; }
    }
}
