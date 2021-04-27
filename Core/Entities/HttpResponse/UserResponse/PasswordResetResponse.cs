using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.HttpResponse.UserResponse
{
    public class PasswordResetResponse
    {
        public string PasswordRecoveryToken { get; set; }
        public string  EmailId { get; set; }
    }
}
