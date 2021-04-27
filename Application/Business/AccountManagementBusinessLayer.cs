using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business
{
    class AccountManagementBusinessLayer
    {
        public static string CreateUserId(string PhoneNo,string EmailId)
        {
            return EmailId.Split("@")[0]+PhoneNo.Substring(0, 4);
        }
        public static string CreateUserIdForFb(string EmailId)
        {
            return EmailId.Split("@")[0] ;
        }
        public static string CreateUserIdForGoogle(string EmailId)
        {
            return EmailId.Split("@")[0];
        }
    }
}
