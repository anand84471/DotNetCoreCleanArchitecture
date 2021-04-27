using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.Abstract
{
    public interface IUserPostgreSqlDbClient<T>
    {
        Task<T> AddUserAsync(T user);
        Task<T> GetUserByEmailAsync(T User);
        Task<T> GetFbUserAsync(T User);
        Task<T> GetGoogleUserAsync(T User);
        Task<bool> UpdateUserAsync(T User);
        Task<T> GetUserByIdAsync(T User);
        Task<bool> UpdateBasicDetailsAsync(T user);
    }
}
