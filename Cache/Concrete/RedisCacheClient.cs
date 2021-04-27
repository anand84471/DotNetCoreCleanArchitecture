using Cache.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Concrete
{
    public class RedisCacheClient : ICacheClient
    {
        IConnectionMultiplexer _connection;
        IDatabase _db;
        public RedisCacheClient(IConnectionMultiplexer connectionMultiplexer)
        {
            _connection = connectionMultiplexer ?? throw new ArgumentNullException("IConnectionMultiplexer");
            _db = _connection.GetDatabase();
        }
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public async Task<string> GetCacheValueAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task<bool> SetCacheValueAsync(string key, string value)
        {
             return await _db.StringSetAsync(key, value);
        }

        public async Task<string> GetHashValueAsync(string hashKey, string member)
        {
            return await _db.HashGetAsync(hashKey, member);
        }
      
        public async Task<bool> SetHashValueAsync(string hashKey, string member,string value)
        {
            return await  _db.HashSetAsync(hashKey, member,value);
        }

    }
}
