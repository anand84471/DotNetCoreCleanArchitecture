using Application.Services.Abstract;
using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Concrete.UserEntities;
using Core.Entities.HttpResponse;
using Core.Entities.HttpResponse.UserResponse;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class AccountService : IAccountService
    {
        IAccountRepository<User> _repo;
        IMapper _mapper;
        ISessionService _session;
        public AccountService(IAccountRepository<User> repository, IMapper mapper, ISessionService session)
        {
            _repo = repository;
            _mapper = mapper;
            _session = session;
        }

        public async Task<UserProfileDetails> GetBaicProfileDetailsAsync(long Id)
        {
            var response = await _repo.GetUserByIdAsync(new User() { UserId = Id }); 
            return _mapper.Map<UserProfileDetails>(response);
        }

        public async Task<bool> LogoutAsync(UserSessions session)
        {
            return await _session.TerminateAsync(session);
        }

        public async Task<ResponseBase> UpdateBaicProfileDetailsAsync(User user)
        {
            ResponseBase response = new ResponseBase();
            if (await _repo.SetBasicDetailsAsync(user))
            {
                response.SetSuccessResponse();
            }
            return response;
        }

    }
}
