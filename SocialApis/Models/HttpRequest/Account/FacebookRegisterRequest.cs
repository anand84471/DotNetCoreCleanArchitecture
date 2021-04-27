using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Models.HttpRequest.Account
{
    public class FacebookRegisterRequest
    {
        [Required]
        [Display(Name = "facebook_id")]
        public string FacebookId { get; set; }
        [Required]
        [Display(Name = "facebook_access_token")]
        public string FacebookAccessToken { get; set; }
        [Required]
        [Display(Name = "full_name")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email_id")]
        public string EmailId { get; set; }
        [Url]
        [Display(Name = "image_url_small")]
        public string ImageUrlSmall { get; set; }
    }
}
