using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.HttpResponse.UserResponse;
using SocialApis.Models.HttpRequest.Account;
using SocialApis.Models.HttpRequest.UserAccountManagement;
using SocialApis.Validation.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Automappers
{
    public class ServiceAutomappers:Profile
    {
        public ServiceAutomappers()
        {
            CreateMap<User, RegisterRequest>().ReverseMap();
            CreateMap<User, FacebookRegisterRequest>().ReverseMap();
            CreateMap<User, GoogleLoginRequest>().ReverseMap();
            CreateMap<User, GoogleRegisterRequest>().ReverseMap();
            CreateMap<User, FacbookLoginRequest>().ReverseMap();
            CreateMap<User, LoginRequest>().ReverseMap();
            CreateMap<User, ForgotPasswordRequest>().ReverseMap();
            CreateMap<User, ProcessPasswordRecoveryRequest>().ReverseMap();//ValidatePasswordResetRequest
            CreateMap<User, ValidatePasswordResetRequest>().ReverseMap();
            //UserAccountDetailsUpdateRequest
            CreateMap<User, UserAccountDetailsUpdateRequest>().ReverseMap();
            CreateMap<User, UserProfileDetails>().ReverseMap();
        }
    }
}
