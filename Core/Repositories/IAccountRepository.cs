using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAccountRepository<T>
    {
        Task<T> GetBasicDetailsAsync(T user);
        Task<bool> SetBasicDetailsAsync(T user);
        Task<T> GetUserByIdAsync(T user);
         //Task<bool> AddOrganizationAsync(Organization organization);
        //Task<bool> AddSchoolDetailsAsync(School school);
        //Task<IEnumerable<School>> GetSchoolsAsync(T id);
        //Task<IEnumerable<Organization>> GetOrganizationsAsync(T id);
    }
}
