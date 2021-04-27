using Application.Services.Abstract;
using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Concrete.UserEntities;
using Core.Entities.HttpResponse;
using Core.Entities.HttpResponse.UserResponse;
using Core.Interfaces;
using Core.Interfaces.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialApis.Authoriazation;
using SocialApis.Models.HttpRequest.UserAccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApis.Controllers
{
    [CustomAuthentication]
    [Route("api/v1/user/account")]
    [ApiController]
    public class AccountManagementApiController : Controller
    {
        IMapper _mapper;
        IAppLogger<AccountManagementApiController> _logger;
        IAccountService _service;
        long _userId;
        IJwtAccountTokenGenerator _tokenValidator;
        string _token;
        public AccountManagementApiController(IMapper mapper,
            IAppLogger<AccountManagementApiController> logger, IAccountService service, IJwtAccountTokenGenerator jwtAccountToken)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
            _tokenValidator = jwtAccountToken;
            
        }
        private void SetId()
        {
            _token  = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            _userId = _tokenValidator.ValidateToken(_token);
        }
        [HttpPost]
        [Route("update/details/basic")]
        public async Task<ResponseBase> UpdateBasicDetails([FromBody] UserAccountDetailsUpdateRequest user)
        {
            
            ResponseBase response = new ResponseBase();
            try
            {
                SetId();
                if(_userId!=-1)
                {
                    user.UserId = _userId;
                    var UserDetails = await _service.UpdateBaicProfileDetailsAsync(_mapper.Map<User>(user));
                    if (UserDetails != null)
                    {
                        response.SetSuccessResponse();
                    }
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "Login", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
       
        [HttpPost]
        [Route("get/basicdetails")]
        public async Task<MasterResponse<UserProfileDetails>> GetBasicDetails()
        {
            MasterResponse<UserProfileDetails> response = new MasterResponse<UserProfileDetails>();
            try
            {
                SetId();
                if (_userId != -1)
                {
                    var UserDetails = await _service.GetBaicProfileDetailsAsync(_userId);
                    response.data = UserDetails;
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "Login", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("logout")]
        public async Task<ResponseBase> Logout()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                SetId();
                if (_userId != -1 && await _service.LogoutAsync(new UserSessions() { Token = _token }))
                {
                    response.SetSuccessResponse();
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "Logout", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("update/password")]
        public async Task<ResponseBase> UpdatePassword()
        {
            ResponseBase response = new ResponseBase();
            try
            {
                SetId();
                if (_userId != -1 && await _service.LogoutAsync(new UserSessions() { Token = _token }))
                {
                    response.SetSuccessResponse();
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "Logout", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
    }
}
