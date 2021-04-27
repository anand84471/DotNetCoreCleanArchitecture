using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Models.HttpRequest.Account
{
    public class GoogleRegisterRequest
    {
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
        [Required]
        public string GoogleId { get; set; }
        [Required]
        public string GoogleAccessToken { get; set; }
    }
}
