using DAL.DTO.User;
using DAL.PostgresqlRepo.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.DbClients
{
    public class SessionDbClient : ISessionDbClient<UserSessionsDTO>
    {
        private readonly PostgreSqlContext _context;
        public SessionDbClient(PostgreSqlContext context)
        {
            _context = context;
           
        }
        private bool InitDB()
        {
            if (_context.Database.CanConnect())
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<UserSessionsDTO> AddAsync(UserSessionsDTO userSession)
        {
            if (InitDB())
            {
                userSession.RowInsertionDatetime = DateTime.UtcNow;
                userSession.RowUpdationDatetime = DateTime.UtcNow;
                userSession.RowActionCount = 1;
                var result = await _context.user_sessions.AddAsync(userSession);
                await _context.SaveChangesAsync();
                await CloseDb();
                return userSession;
            }
            return null;
        }

        public Task<UserSessionsDTO> GetByIdAsync(UserSessionsDTO User)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UserSessionsDTO userSession)
        {
            bool result = false;
            if (InitDB())
            {
                userSession.RowActionCount += 1;
                userSession.RowUpdationDatetime = DateTime.UtcNow;
                _context.user_sessions.Attach(userSession);
                _context.Entry(userSession).Property(x => x.IsSessionLogout).IsModified = true;
                _context.Entry(userSession).Property(x => x.SessionLogoutTime).IsModified = true;
                _context.Entry(userSession).Property(x => x.RowActionCount).IsModified = true;
                _context.Entry(userSession).Property(x => x.RowUpdationDatetime).IsModified = true;
                result= await _context.SaveChangesAsync() > 0;
                await CloseDb();
            }
            return result;
        }
        public async Task<UserSessionsDTO> GetSessionByToken(UserSessionsDTO user)
        {
            if (InitDB())
            {
                var session = await Task.Run(() => _context.user_sessions.Where(u => u.Token == user.Token).AsNoTracking().
           FirstOrDefault());
                await CloseDb();
                return session;
            }
            return null;
        }

      
        public async Task CloseDb()
        {
            await _context.Database.CloseConnectionAsync();
        }
    }
}
