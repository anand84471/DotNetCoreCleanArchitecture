using AutoMapper;
using Core.Entities.Concrete;
using Core.Repositories;
using Core.Repositories.Abstract;
using DAL.DTO;
using DAL.DTO.User;
using DAL.PostgresqlRepo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository: IUserRepository<User>
    {
        IUserPostgreSqlDbClient<UserDTO> _dbclient;
        IMapper _mapper;
        public UserRepository(IUserPostgreSqlDbClient<UserDTO> userPostgreSqlDbClient,IMapper mapper )
        {
            _dbclient = userPostgreSqlDbClient ?? throw new ArgumentNullException("IUserPostgreSqlDbClient");
            _mapper = mapper ?? throw new ArgumentNullException("IMapper");
        }
        public async Task<User> AddAsync(User user)
        {
            var response=await _dbclient.AddUserAsync(_mapper.Map<UserDTO>(user));
            return _mapper.Map<User>(response);
        }
        public Task<bool> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(User Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAsync(User user)
        {
            var response = await _dbclient.GetUserByEmailAsync(_mapper.Map<UserDTO>(user));
            return _mapper.Map<User>(response);
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            return await _dbclient.UpdateUserAsync(_mapper.Map<UserDTO>(entity));
        }

        
    }
}
