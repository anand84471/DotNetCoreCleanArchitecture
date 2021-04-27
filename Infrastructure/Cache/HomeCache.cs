using Cache.Interfaces;
using Core.Cache;
using Core.Cache.CacheKeys;
using Core.Entities.Base;
using Core.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public class HomeCache : IHomeCache
    {
        ICacheClient _cache;
        public HomeCache(ICacheClient cacheClient )
        {
            _cache = cacheClient ?? throw new ArgumentNullException("ICacheClient");
        }
        public async Task<IEnumerable<CountryBase>> GetCountriesAsync()
        {
            var data=await _cache.GetHashValueAsync(CacheKeyNamesConstants.MASTER_DATA_CACHE_KEY, CacheKeyNamesConstants.COUNTRY_DATA_CACHE_KEY);
            if (data != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<CountryBase>>(data);
            }
            return null;
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            var data = await _cache.GetHashValueAsync(CacheKeyNamesConstants.MASTER_DATA_CACHE_KEY, CacheKeyNamesConstants.GENDER_DATA_CACHE_KEY);
            if (data != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Gender>>(data);
            }
            return null;
        }
        public async Task<bool> SetGendersAsync(IEnumerable<Gender> genders)
        {
            var gendersSerialized=JsonConvert.SerializeObject(genders);
            return await _cache.SetHashValueAsync(CacheKeyNamesConstants.MASTER_DATA_CACHE_KEY, CacheKeyNamesConstants.GENDER_DATA_CACHE_KEY,gendersSerialized);  
        }
        public async Task<bool> SetCountriesAsync(IEnumerable<CountryBase> countries)
        {
            var gendersSerialized = JsonConvert.SerializeObject(countries);
            return await _cache.SetHashValueAsync(CacheKeyNamesConstants.MASTER_DATA_CACHE_KEY, CacheKeyNamesConstants.COUNTRY_DATA_CACHE_KEY, gendersSerialized);
        }
    }
}
