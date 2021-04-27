using Application.Services.Abstract;
using Core.Entities.HttpResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Authoriazation
{
    public class CustomAuthentication : Attribute, IAsyncAuthorizationFilter
    {
        ISessionService _session;
        public CustomAuthentication()
        {
            
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            _session = (ISessionService)context.HttpContext.RequestServices.GetService(typeof(ISessionService));
            string token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(); ;
            if (token != null)
            {
                var isValid = await _session.ValidateSessionAsync(token);
                if (isValid)
                {
                    context.HttpContext.Response.StatusCode = 200;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = 401; //Unauthorized
                    var response = new ResponseBase();
                    response.Error = new ErrorResponseBase()
                    {
                        ErrorCode = StatusCodes.Status401Unauthorized,
                        ErrorMessage = "Unauthorized"
                    };
                    context.Result = new JsonResult(response);
                }
            }
            else
            {
                // no authorization header
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized }; //Unauthorized
                return;
            }
            
        }
    }
}
