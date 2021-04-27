using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<CountryBase>> GetCountriesAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<IEnumerable<Organization>> GetOrganizationsAsync(SearchRequestBase searchRequestBase);
        Task<IEnumerable<School>> GetSchoolsAsync(SearchRequestBase searchRequestBase);
        Task<IEnumerable<Tag>> GetTagsAsync(SearchRequestBase searchRequestBase);
        
        Task<School> AddSchoolAsync(School school);
        Task<Organization> AddOrganizationAsync(Organization organization);
    }
}
