using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface ISchoolService
    {
        Task<School> AddAsync(School school);
    }
}
