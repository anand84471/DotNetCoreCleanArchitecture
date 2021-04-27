using Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository<T>:IRepository<T>
    {
        Task<T> GetUserByEmailAsync(T User);
    }
}
