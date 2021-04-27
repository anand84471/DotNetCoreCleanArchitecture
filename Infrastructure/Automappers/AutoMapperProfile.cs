using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Concrete.UserEntities;
using Core.Entities.HttpResponse.UserResponse;
using DAL.DTO;
using DAL.DTO.User;
using EmailService.Models;
using SmsService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Automappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Email, EmailModel>().ReverseMap();
            CreateMap<Sms, SmsModel>().ReverseMap();
            CreateMap<Organization, OrganizationDTO>().ReverseMap();
            CreateMap<School, SchoolDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<UserSessionsDTO, UserSessions>().ReverseMap();
        }
    }
}
