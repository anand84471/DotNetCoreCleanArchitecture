using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache
{
    public interface IHomeCache
    {
        Task<IEnumerable<CountryBase>> GetCountriesAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<bool> SetGendersAsync(IEnumerable<Gender> genders);
        Task<bool> SetCountriesAsync(IEnumerable<CountryBase> countries);
    }
}
