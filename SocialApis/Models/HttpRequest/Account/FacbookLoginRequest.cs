using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Models.HttpRequest.Account
{
    public class FacbookLoginRequest
    {
        [Required]
        [Display(Name = "facebook_id")]
        public string FacebookId { get; set; }
        [Required]
        [Display(Name = "facebook_access_token")]
        public string FacebookAccessToken { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email_id")]
        public string EmailId { get; set; }
       
    }
}
