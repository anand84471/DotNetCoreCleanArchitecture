using Application.Services.Abstract;
using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using Core.Entities.HttpResponse;
using Core.Interfaces;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApis.Controllers
{
    [Route("api/v1/home")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private IHomeService _service;
        private IAppLogger<HomeApiController> _logger;
        public HomeApiController(IHomeService service,IAppLogger<HomeApiController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetContries")]
        public async Task<ListResponse<CountryBase>> GetContries()
        {
            ListResponse<CountryBase> response = new ListResponse<CountryBase>();
            try
            {
                response.Records= await _service.GetCountriesAsync();
                if (response.Records != null) response.SetSuccessResponse();
            }
            catch(Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetContries", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpGet]
        [Route("GetGenders")]
        public async Task<ListResponse<Gender>> GetGenders()
        {
            ListResponse<Gender> response = new ListResponse<Gender>();
            try
            {
                response.Records = await _service.GetGendersAsync();
                if (response.Records != null) response.SetSuccessResponse();
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
        [HttpGet]
        [Route("search/school")]
        public async Task<ListResponse<School>> GetSchools(SearchRequestBase request)
        {
            ListResponse<School> response = new ListResponse<School>();
            try
            {
                response.Records = await _service.GetSchoolsAsync(request);
                if (response.Records != null) response.SetSuccessResponse();
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetSchools", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpGet]
        [Route("search/organization")]
        public async Task<ListResponse<Organization>> GetOrganizations(SearchRequestBase request)
        {
            ListResponse<Organization> response = new ListResponse<Organization>();
            try
            {
                response.Records = await _service.GetOrganizationsAsync(request);
                if (response.Records != null) response.SetSuccessResponse();
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetOrganizations", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
        [HttpGet]
        [Route("search/tag")]
        public async Task<ListResponse<Tag>> GetTags(SearchRequestBase request)
        {
            ListResponse<Tag> response = new ListResponse<Tag>();
            try
            {
                response.Records = await _service.GetTagsAsync(request);
                if (response.Records != null) response.SetSuccessResponse();
            }
            catch (Exception Ex)
            {
                StringBuilder m_strLogMessage = new StringBuilder();
                m_strLogMessage.Append("\n ----------------------------Exception Stack Trace--------------------------------------");
                m_strLogMessage = m_strLogMessage.AppendFormat("[Method] : {0}  {1} ", "GetOrganizations", Ex.ToString());
                m_strLogMessage.Append("Exception occured in method :" + Ex.TargetSite);
                _logger.LogError(m_strLogMessage);
            }
            return response;
        }
    }
}
