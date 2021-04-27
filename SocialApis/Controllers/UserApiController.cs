using Application.Services.Abstract; 
using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.HttpResponse;
using Core.Entities.HttpResponse.UserResponse;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SocialApis.Models.HttpRequest.Account;
using SocialApis.Validation.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApis.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserApiController : Controller
    {
        private IUserService _service;
        private IAppLogger<UserApiController> _logger;
        IMapper _mapper;
        public UserApiController(IUserService service, IAppLogger<UserApiController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("add")]
        public async Task<MasterResponse<UserModel>> Add([FromBody]RegisterRequest user)
        {
            MasterResponse<UserModel> response=new MasterResponse<UserModel>();
            try
            {
                var UserDetails= await _service.AddAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
                    response.data = UserDetails;
                }
            }
            catch(Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "Add", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("login")]
        public async Task<MasterResponse<UserModel>> Login([FromBody] LoginRequest user)
        {
            MasterResponse<UserModel> response = new MasterResponse<UserModel>();
            try
            {
                var UserDetails = await _service.ValidateUserAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
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
        [Route("add/google")]
        public async Task<MasterResponse<UserModel>> AddGoogleAccount([FromBody] GoogleRegisterRequest user)
        {
            MasterResponse<UserModel> response = new MasterResponse<UserModel>();
            try
            {
                var UserDetails = await _service.AddGoogleAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
                    response.data = UserDetails;
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetContries", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("add/fb")]
        public async Task<MasterResponse<UserModel>> AddFacebookAccount([FromBody] FacebookRegisterRequest user)
        {
            MasterResponse<UserModel> response = new MasterResponse<UserModel>();
            try
            {
                var UserDetails = await _service.AddFbAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
                    response.data = UserDetails;
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetContries", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("login/fb")]
        public async Task<MasterResponse<UserModel>> ValidateFacebookProfile([FromBody] FacbookLoginRequest user)
        {
            MasterResponse<UserModel> response = new MasterResponse<UserModel>();
            try
            {
                var UserDetails = await _service.ValidateFbAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
                    response.data = UserDetails;
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetContries", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("login/google")]
        public async Task<MasterResponse<UserModel>> ValidateGoogleProfile([FromBody] GoogleLoginRequest user)
        {
            MasterResponse<UserModel> response = new MasterResponse<UserModel>();
            try
            {
                var UserDetails = await _service.ValidateGoogleAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
                    response.data = UserDetails;
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetContries", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("account/reset/request")]
        public async Task<MasterResponse<PasswordResetResponse>> AccountReset([FromBody] ForgotPasswordRequest request)
        {
            MasterResponse<PasswordResetResponse> response = new MasterResponse<PasswordResetResponse>();
            try
            {
                return   await _service.SendPasswordRecoveryAsync(_mapper.Map<User>(request));
                
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "AccountReset", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("account/reset/validate")]
        public async Task<ResponseBase> ValidatePasswordReset([FromBody] ValidatePasswordResetRequest request)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                if(await _service.ValidatePasswordRecoveryAsync(_mapper.Map<User>(request)))
                {
                    response.SetSuccessResponse();
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "AccountReset", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("account/reset/process")]
        public async Task<ResponseBase> ProcessPasswordReset([FromBody] ProcessPasswordRecoveryRequest request)
        {
            ResponseBase response = new ResponseBase();
            try
            {
                if (await _service.ProcessPasswordResetAsync(_mapper.Map<User>(request)))
                {
                    response.SetSuccessResponse();
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "AccountReset", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpPost]
        [Route("account/update/school")]
        public async Task<MasterResponse<UserModel>> UpdateSchool([FromBody] RegisterRequest user)
        {
            MasterResponse<UserModel> response = new MasterResponse<UserModel>();
            try
            {
                var UserDetails = await _service.AddAsync(_mapper.Map<User>(user));
                if (UserDetails != null)
                {
                    response.SetSuccessResponse();
                    response.data = UserDetails;
                }
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "UpdateSchool", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
    }
}
