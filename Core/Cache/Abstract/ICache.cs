using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache.Abstract
{
    public interface ICache<T>
    {
        Task<T> Get(T entity);
        Task Set(T entity);
    }
}
