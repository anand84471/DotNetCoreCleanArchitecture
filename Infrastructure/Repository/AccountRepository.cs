using AutoMapper;
using Core.Entities.Concrete;
using Core.Repositories;
using DAL.DTO;
using DAL.PostgresqlRepo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository<User>
    {
        IMapper _mapper;
        IUserPostgreSqlDbClient<UserDTO> _dbclient;
        public AccountRepository(IUserPostgreSqlDbClient<UserDTO> userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _dbclient = userRepository??throw new ArgumentNullException("IUserPostgreSqlDbClient");
        }
        public async Task<User> GetBasicDetailsAsync(User user)
        {
            
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(User user)
        {
            var response= await _dbclient.GetUserByIdAsync(_mapper.Map<UserDTO>(user));
            return _mapper.Map<User>(response);
        }

        public async Task<bool> SetBasicDetailsAsync(User user)
        {
            return await  _dbclient.UpdateBasicDetailsAsync(_mapper.Map<UserDTO>(user));
        }
    }
}
