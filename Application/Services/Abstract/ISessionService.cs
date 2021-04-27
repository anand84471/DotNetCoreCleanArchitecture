using Core.Entities.Concrete.UserEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface ISessionService
    {
        public Task<bool> ValidateSessionAsync(string token);
        public Task<bool> AddSession(UserSessions session);
        public Task<bool> TerminateAsync(UserSessions session);
    }
}
