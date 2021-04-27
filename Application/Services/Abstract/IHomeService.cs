using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IHomeService
    {
        Task<IEnumerable<CountryBase>> GetCountriesAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<IEnumerable<School>> GetSchoolsAsync(SearchRequestBase searchRequestBase);
        Task<IEnumerable<Organization>> GetOrganizationsAsync(SearchRequestBase searchRequestBase);
        Task<IEnumerable<Tag>> GetTagsAsync(SearchRequestBase searchRequestBase);
    }
}
