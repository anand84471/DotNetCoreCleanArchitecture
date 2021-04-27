using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class UserDTO
    {
        public long UserId{get;set;}
        public string FullName{get;set;}
        public string UserName{get;set;}
        public string EmailId{get;set;}
        public string PhoneNo{get;set;}
        public string Address{get;set;}
        public int? CountryCode{get;set;}
        public int? GenderId{get;set;}
        public DateTime? DateOfBirth{get;set;}
        public string ImageUrlSmall{get;set;}
        public string ImageUrlMedium{get;set;}
        public string ImageUrlLarge{get;set;}
        public string HashedPassword{get;set;}
        public bool IsEmailVarified{get;set;}
        public bool IsPhoneNoVarified{get;set;}
        public string LastEmailVarificationOtp{get;set;}
        public DateTime? LastLoginTime{get;set;}
        public bool IsDeactivated{get;set;}
        public DateTime? DeactivationDatetime{get;set;}
        public bool IsRequestForDelete{get;set;}
        public DateTime? DeletionRequestTime{get;set;}
        public DateTime RowInsertionDatetime{get;set;}
        public DateTime RowUpdationDatetime{get;set;}
        public int RowActionCount{get;set;}
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public DateTime? LastPasswordRecoveryRequestDatetime { get; set; }
        public string PasswordRecoveryOtp { get; set; }
        public string PasswordRecoveryToken { get; set; }
        public bool? IsLastPasswordRecovered { get; set; }
        public DateTime? LastPasswordRecoveryDatetime { get; set; }
        public bool? IsLastPasswordOtpVarified { get; set; }
        public UserDTO()
        {
            RowActionCount = 1;
            RowInsertionDatetime = DateTime.UtcNow;
            RowUpdationDatetime = DateTime.UtcNow;
        }
    }
}
