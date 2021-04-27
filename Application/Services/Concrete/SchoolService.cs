using Application.Services.Abstract;
using AutoMapper;
using Core.Cache;
using Core.Entities.Concrete;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class SchoolService : ISchoolService
    {
        IHomeRepository _repo;
        IHomeCache _cache;
        IMapper _mapper;
        public SchoolService(IHomeRepository homerepo, IHomeCache cache,IMapper mapper)
        {
            _repo = homerepo ?? throw new ArgumentNullException("IHomeRepository");
            _cache = cache;
            _mapper = mapper;
        }
        public async Task<School> AddAsync(School school)
        {
            return await _repo.AddSchoolAsync(school);
        }
    }
}
