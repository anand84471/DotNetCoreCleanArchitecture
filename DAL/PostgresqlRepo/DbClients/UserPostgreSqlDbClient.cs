using DAL.DTO;
using DAL.PostgresqlRepo.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.DbClients
{
    public class UserPostgreSqlDbClient : IUserPostgreSqlDbClient<UserDTO>
    {
        private readonly PostgreSqlContext _context;
        public UserPostgreSqlDbClient(PostgreSqlContext context)
        {
            _context = context;
           
        }
        public async Task<UserDTO> AddUserAsync(UserDTO user)
        {
            user.RowInsertionDatetime = DateTime.UtcNow;
            user.RowUpdationDatetime = DateTime.UtcNow;
            user.RowActionCount = 1;
            var result=await _context.user_details.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<UserDTO> GetFbUserAsync(UserDTO User)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetGoogleUserAsync(UserDTO User)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUserAsync(UserDTO user)
        {
            return null;
        }

        public async Task<UserDTO> GetUserByEmailAsync(UserDTO User)
        {
            var user = await Task.Run(() => _context.user_details.Where(u=>u.EmailId==User.EmailId).
            FirstOrDefault());
            return user;

        }

        public async Task<UserDTO> GetUserByIdAsync(UserDTO User)
        {
            var user = await Task.Run(() => _context.user_details.Where(u => u.UserId == User.UserId).
            FirstOrDefault());
            return user;
        }

        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            var local = _context.Set<UserDTO>().Local.FirstOrDefault(entry => entry.UserId.Equals(user.UserId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(user).State = EntityState.Modified;

            // save 
            user.RowActionCount += 1;
            user.RowUpdationDatetime = DateTime.UtcNow;
            await Task.Run(() => _context.user_details.Update(user));
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdatePasswordAsync(UserDTO user)
        {
            _context.user_details.Attach(user);
            _context.Entry(user).Property(x => x.HashedPassword).IsModified = true;
            return await _context.SaveChangesAsync()>0;
        }
        public async Task<bool> UpdateBasicDetailsAsync(UserDTO user)
        {
            user.RowActionCount += 1;
            user.RowUpdationDatetime = DateTime.UtcNow;
            _context.user_details.Attach(user);
            _context.Entry(user).Property(x => x.CountryCode).IsModified = true;
            _context.Entry(user).Property(x => x.GenderId).IsModified = true;
            _context.Entry(user).Property(x => x.DateOfBirth).IsModified = true;
            _context.Entry(user).Property(x => x.RowActionCount).IsModified = true;
            _context.Entry(user).Property(x => x.RowUpdationDatetime).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
