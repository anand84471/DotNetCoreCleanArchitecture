using Core.Entities.Base;
using Core.Entities.Concrete;
using Core.Entities.HttpRequest;
using DAL.DTO;
using DAL.PostgresqlRepo.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.DbClients
{
    public class HomePostgreSqlDbClient : IHomePostgreSqlDbClient
    {
        private readonly PostgreSqlContext _context;
        public HomePostgreSqlDbClient(PostgreSqlContext context)
        {
            _context = context;
            if (_context.Database.CanConnect())
            {
                
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async Task<IEnumerable<CountryBase>> GetCountriesAsync()
        {

            IEnumerable<CountryBase> countries = await Task.Run(()=> _context.country.Select(c =>
                 new CountryBase()
                 {
                     Id = c.Id,
                     Name = c.Name
                 }));
            return countries;
        }

        public async Task<IEnumerable< Gender>> GetGendersAsync()
        {
            IEnumerable<Gender> countries = await Task.Run(() => _context.master_gender.
            Select(g =>
                 new Gender()
                 {
                     Id = g.Id,
                     Name = g.Name
                 }));
            return countries;
        }
        public async Task<IEnumerable<SchoolDTO>> GetSchoolsAsync(SearchRequestBase search)
        {
            IEnumerable<SchoolDTO> schools = await Task.Run(() => _context.school_details.
            Where(g =>g.Name.Contains(search.SearchString)).Skip(search.NoOfRowsFectched).Take(search.MaxRowsToBeFectched) .
            Select(s=>
                 new SchoolDTO()
                 {
                     SchoolId =s.SchoolId,
                     Name = s.Name
                 }));
            return schools;
        }
        public async Task<IEnumerable<OrganizationDTO>> GetOrganizationsAsync(SearchRequestBase search)
        {
            IEnumerable<OrganizationDTO> organizations = await Task.Run(() => _context.organizations_details.
            Where(g => g.Name.Contains(search.SearchString)).Skip(search.NoOfRowsFectched).Take(search.MaxRowsToBeFectched).
            Select(s =>
                 new OrganizationDTO()
                 {
                     OrganizationId = s.OrganizationId,
                     Name = s.Name
                 }));
            return organizations;
        }

        public async Task<SchoolDTO> AddSchoolAsync(SchoolDTO school)
        {
            school.RowInsertionDatetime = DateTime.UtcNow;
            school.RowUpdationDatetime = DateTime.UtcNow;
            school.RowActionCount = 1;
            var result = await _context.school_details.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<OrganizationDTO> AddOrganizationAsync(OrganizationDTO organization)
        {
            organization.RowInsertionDatetime = DateTime.UtcNow;
            organization.RowUpdationDatetime = DateTime.UtcNow;
            organization.RowActionCount = 1;
            var result = await _context.organizations_details.AddAsync(organization);
            await _context.SaveChangesAsync();
            return organization;
        }

    }
}
