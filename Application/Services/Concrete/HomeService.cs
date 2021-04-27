using Application.Services.Abstract;
using Core.Cache;
using Core.Constants;
using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class HomeService : IHomeService
    {
        IHomeRepository _repo;
        IHomeCache _cache;
        public HomeService(IHomeRepository homerepo,IHomeCache cache)
        {
            _repo = homerepo ?? throw new ArgumentNullException("IHomeRepository");
            _cache = cache;
        }
        public async Task<IEnumerable<CountryBase>> GetCountriesAsync()
        {
            var countries = await _cache.GetCountriesAsync();
            if (countries == null)
            {
                countries = await _repo.GetCountriesAsync();
                await _cache.SetCountriesAsync(countries);
            }
            return countries;
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            var genders =await _cache.GetGendersAsync();
            if (genders == null)
            {
                genders= await _repo.GetGendersAsync();
                await _cache.SetGendersAsync(genders);
            }
            return genders;
        }

        public async Task<IEnumerable<Organization>> GetOrganizationsAsync(SearchRequestBase searchRequestBase)
        {
            searchRequestBase.MaxRowsToBeFectched = ConfigConstants.MAX_ROWS_TO_BE_FECTCHED;
            return await _repo.GetOrganizationsAsync(searchRequestBase);
        }

        public async Task<IEnumerable<School>> GetSchoolsAsync(SearchRequestBase searchRequestBase)
        {
            searchRequestBase.MaxRowsToBeFectched = ConfigConstants.MAX_ROWS_TO_BE_FECTCHED;
            return await _repo.GetSchoolsAsync(searchRequestBase);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync(SearchRequestBase searchRequestBase)
        {
            searchRequestBase.MaxRowsToBeFectched = ConfigConstants.MAX_ROWS_TO_BE_FECTCHED;
            return await _repo.GetTagsAsync(searchRequestBase);
        }
    }
}
