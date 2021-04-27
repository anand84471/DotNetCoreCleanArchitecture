using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Interfaces
{
    public interface ICacheClient
    {
        Task<string> GetCacheValueAsync(string key);
        Task<bool> SetCacheValueAsync(string Key,string Value);
        Task<string> GetHashValueAsync(string hashKey, string member);
        Task<bool> SetHashValueAsync(string hashKey, string member, string value);
    }
}
