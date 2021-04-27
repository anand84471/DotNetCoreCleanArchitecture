using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.Abstract
{
    public interface IHomePostgreSqlDbClient
    {
        Task<IEnumerable<CountryBase>> GetCountriesAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<IEnumerable<SchoolDTO>> GetSchoolsAsync(SearchRequestBase search);
        Task<IEnumerable<OrganizationDTO>> GetOrganizationsAsync(SearchRequestBase search);
        Task<SchoolDTO> AddSchoolAsync(SchoolDTO school);
        Task<OrganizationDTO> AddOrganizationAsync(OrganizationDTO organization);

    }
}
