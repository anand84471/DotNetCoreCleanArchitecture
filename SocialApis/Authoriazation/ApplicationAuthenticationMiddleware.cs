using Application.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis.Authoriazation
{
    public class ApplicationAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        ISessionService _session;
        public ApplicationAuthenticationMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISessionService session)
        {
            _session = session;
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(); ;
            if (token != null)
            {
                var isValid = await _session.ValidateSessionAsync(token);
                if (isValid)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }

    }
}
