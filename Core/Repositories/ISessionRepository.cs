using Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISessionRepository<T>: IRepository<T>
    {
        Task<T> GetByTokenAsync(T Id);
        Task<bool> TerminateAsync(T Id);
    }
}
