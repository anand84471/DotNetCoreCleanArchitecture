using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.Abstract
{
    public interface IDbClient<T>
    {
        Task<T> AddAsync(T user);
        Task<bool> UpdateAsync(T User);
        Task<T> GetByIdAsync(T User);
    }
}
