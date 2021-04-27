using Application.Services.Abstract;
using Core.Entities.Concrete.UserEntities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class SessionService : ISessionService
    {
        ISessionRepository<UserSessions> _repo;
        public SessionService(ISessionRepository<UserSessions> sessionRepository)
        {
            _repo = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }
        public async Task<bool> AddSession(UserSessions session)
        {
            return await _repo.AddAsync(session) != null;
        }

        public async Task<bool> TerminateAsync(UserSessions session)
        {
            var sessionInfo = await _repo.GetByTokenAsync(session);
            if (!sessionInfo.IsSessionLogout)
            {
                sessionInfo.IsSessionLogout = true;
                sessionInfo.SessionLogoutTime = DateTime.UtcNow;
                return await _repo.UpdateAsync(sessionInfo);
            }
            return false;
        }

        public async Task<bool> ValidateSessionAsync(string token)
        {
            var session = await _repo.GetByTokenAsync(new UserSessions() { Token=token}); ;
            if (session != null&&!session.IsSessionLogout)
            {
                return true;
            }
            return false;
        }
    }
}
