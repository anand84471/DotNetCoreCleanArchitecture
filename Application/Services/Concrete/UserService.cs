using Application.Business;
using Application.Security.Jwt;
using Application.Security.Password;
using Application.Services.Abstract;
using AutoMapper;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Entities.Concrete.UserEntities;
using Core.Entities.HttpResponse;
using Core.Entities.HttpResponse.UserResponse;
using Core.Interfaces;
using Core.Interfaces.Security;
using Core.Repositories;
using Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class UserService: IUserService
    {
        IUserRepository<User> _repo;
        IMapper _mapper;
        IJwtAccountTokenGenerator _tokenHelper;
        ISmsService _smsClient;
        ISessionService _session;
        public UserService(IUserRepository<User> userRepository, IMapper mapper, IJwtAccountTokenGenerator tokenHelper
            , ISmsService smsService,ISessionService session)
        {
            _repo = userRepository ?? throw new ArgumentNullException("IUserRepository");
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _smsClient = smsService;
            _session = session;
        }

        public async Task<UserModel> AddAsync(User user)
        {
            user.HashedPassword =JsonConvert.SerializeObject(PasswordUtils.EncryptPassword(user.Password));
            user.UserName = AccountManagementBusinessLayer.CreateUserId(user.PhoneNo,user.EmailId);
            user.PhoneNo = user.PhoneCode +"-"+user.PhoneNo;
            var userInfo= await _repo.AddAsync(user);
            userInfo.JwtToken = _tokenHelper.GenerateJSONWebToken(userInfo);
            return _mapper.Map<UserModel>(userInfo);
        }

        public async Task<UserModel> ValidateUserAsync(User user)
        {
            var userInfo = await _repo.GetUserByEmailAsync(user);
            var hash = JsonConvert.DeserializeObject<HashSalt>(userInfo.HashedPassword);
            if (PasswordUtils.VerifyPassword(user.Password, hash.Salt, hash.Hash)){
                userInfo.JwtToken = _tokenHelper.GenerateJSONWebToken(userInfo);
                await _session.AddSession(new UserSessions()
                {
                    UserId=userInfo.UserId,
                    Token = userInfo.JwtToken,
                }
                );
                return _mapper.Map<UserModel>(userInfo);
            }
            return null;
        }

        public async Task<MasterResponse<PasswordResetResponse>> SendPasswordRecoveryAsync(User user)
        {
            MasterResponse<PasswordResetResponse> response = new MasterResponse<PasswordResetResponse>();
            var userInfo = await _repo.GetUserByEmailAsync(user);
            if (userInfo != null)
            {
                var passwordResetResponse = new PasswordResetResponse();
                passwordResetResponse.EmailId = userInfo.EmailId;
                passwordResetResponse.PasswordRecoveryToken = UtilsHelper.GetGuid();
                userInfo.PasswordRecoveryOtp = UtilsHelper.GetOtp(ConfigConstants.MAX_PASSWORD_RECOVERY_OTP);
                userInfo.PasswordRecoveryToken = passwordResetResponse.PasswordRecoveryToken;
                userInfo.LastPasswordRecoveryRequestDatetime = DateTime.UtcNow;
                await _smsClient.SendSmsAsync(new Sms() { 
                    Message= userInfo.PasswordRecoveryOtp,
                    PhoneNo=userInfo.PhoneNo.Replace("-","")
                });
                if (await _repo.UpdateAsync(userInfo)){
                    response.data = passwordResetResponse;
                    response.SetSuccessResponse();
                }    
            }
            else
            {
                response.SetError(ErrorConstants.EMAIL_NOT_FOUND,
                    ErrorConstants.EMAIL_NOT_FOUND_MSG);
            }
            return response;
        }

        public async Task<bool> ValidatePasswordRecoveryAsync(User user)
        {
            bool result = false;
            var userInfo = await _repo.GetUserByEmailAsync(user);
            if (userInfo != null)
            {
                if (userInfo.PasswordRecoveryOtp == user.PasswordRecoveryOtp&&userInfo.PasswordRecoveryToken== user.PasswordRecoveryToken)
                {
                    userInfo.IsLastPasswordOtpVarified = true;
                    result = await _repo.UpdateAsync(userInfo);
                }
            }
            return result;
        }

        public async Task<bool> ProcessPasswordResetAsync(User user)
        {
            bool result = false;
            var userInfo = await _repo.GetUserByEmailAsync(user);
            if (userInfo != null)
            {
                if (userInfo.IsLastPasswordOtpVarified==true&& userInfo.PasswordRecoveryToken == user.PasswordRecoveryToken)
                {
                    userInfo.HashedPassword= JsonConvert.SerializeObject(PasswordUtils.EncryptPassword(user.Password));
                    result = await _repo.UpdateAsync(userInfo);
                }
            }
            return result;
        }

        public async Task<UserModel> AddFbAsync(User user)
        {
            user.HashedPassword = "";//for fb user
            user.UserName = AccountManagementBusinessLayer.CreateUserIdForFb(user.EmailId);
            var userInfo = await _repo.AddAsync(user);
            userInfo.JwtToken = _tokenHelper.GenerateJSONWebToken(userInfo);
            return _mapper.Map<UserModel>(userInfo);
        }

        public async Task<UserModel> ValidateFbAsync(User user)
        {
            var userInfo = await _repo.GetUserByEmailAsync(user);
            if(userInfo.FacebookId==user.FacebookId&& userInfo.EmailId == user.EmailId)
            {
                userInfo.JwtToken = _tokenHelper.GenerateJSONWebToken(userInfo);
                return _mapper.Map<UserModel>(userInfo);
            }
            return null;
        }

        public async Task<UserModel> AddGoogleAsync(User user)
        {
            user.HashedPassword = "";//for fb user
            user.UserName = AccountManagementBusinessLayer.CreateUserIdForGoogle(user.EmailId);
            var userInfo = await _repo.AddAsync(user);
            userInfo.JwtToken = _tokenHelper.GenerateJSONWebToken(userInfo);
            return _mapper.Map<UserModel>(userInfo);
        }

        public async Task<UserModel> ValidateGoogleAsync(User user)
        {
            var userInfo = await _repo.GetUserByEmailAsync(user);
            if (userInfo.GoogleId == user.GoogleId && userInfo.EmailId == user.EmailId)
            {
                userInfo.JwtToken = _tokenHelper.GenerateJSONWebToken(userInfo);
                return _mapper.Map<UserModel>(userInfo);
            }
            return null;
        }
    }
}
