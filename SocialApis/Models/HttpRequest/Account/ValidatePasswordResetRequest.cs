using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Models.HttpRequest.Account
{
    public class ValidatePasswordResetRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "email_id")]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "password_recovery_otp")]
        public string PasswordRecoveryOtp { get; set; }
        [Required]
        [Display(Name = "password_reset_token")]
        public string PasswordRecoveryToken { get; set; }
    }
}
