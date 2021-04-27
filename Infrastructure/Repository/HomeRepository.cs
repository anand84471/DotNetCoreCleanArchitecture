using AutoMapper;
using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using Core.Repositories;
using DAL.DTO;
using DAL.PostgresqlRepo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class HomeRepository: IHomeRepository
    {

        IHomePostgreSqlDbClient _dbclient;
        IMapper _mapper;
        public HomeRepository(IHomePostgreSqlDbClient homePostgreSqlDbClient,IMapper mapper)
        {
            _dbclient = homePostgreSqlDbClient ?? throw new ArgumentNullException("IHomePostgreSqlDbClient");
            _mapper = mapper ?? throw new ArgumentNullException("IMapper");
        }

        public async Task<Organization> AddOrganizationAsync(Organization organization)
        {
            var response = await _dbclient.AddOrganizationAsync(_mapper.Map<OrganizationDTO>(organization));
            return _mapper.Map<Organization>(response);
        }

        public async Task<School> AddSchoolAsync(School school)
        {
            var response = await _dbclient.AddSchoolAsync(_mapper.Map<SchoolDTO>(school));
            return _mapper.Map<School>(response);
        }

        public async Task<IEnumerable<CountryBase>> GetCountriesAsync()
        {
            return await _dbclient.GetCountriesAsync();
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await _dbclient.GetGendersAsync();
        }

        public async Task<IEnumerable<Organization>> GetOrganizationsAsync(SearchRequestBase searchRequestBase)
        {
            var organizations= await _dbclient.GetOrganizationsAsync(searchRequestBase);
            return _mapper.Map< IEnumerable < Organization >> (organizations);

        }

        public async Task<IEnumerable<School>> GetSchoolsAsync(SearchRequestBase searchRequestBase)
        {
            var schools = await _dbclient.GetSchoolsAsync(searchRequestBase);
            return _mapper.Map<IEnumerable<School>>(schools);
        }

        public Task<IEnumerable<Tag>> GetTagsAsync(SearchRequestBase searchRequestBase)
        {
            throw new NotImplementedException();
        }
    }
}
