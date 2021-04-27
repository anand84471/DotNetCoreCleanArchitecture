using AutoMapper;
using Core.Entities.Concrete.UserEntities;
using Core.Repositories;
using Core.Repositories.Abstract;
using DAL.DTO.User;
using DAL.PostgresqlRepo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SessionRepository : ISessionRepository<UserSessions>
    {
        ISessionDbClient<UserSessionsDTO> _dbclient;
        IMapper _mapper;
        public SessionRepository(ISessionDbClient<UserSessionsDTO> sessionDbClient, IMapper mapper)
        {
            _dbclient = sessionDbClient ?? throw new ArgumentNullException("ISessionDbClient");
            _mapper = mapper??throw new ArgumentNullException("IMapper");
        }
        public async Task<UserSessions> AddAsync(UserSessions entity)
        {
            
            var response = await _dbclient.AddAsync(_mapper.Map<UserSessionsDTO>(entity));
            return _mapper.Map<UserSessions>(response);
        }

        public Task DeleteAsync(UserSessions entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSessions>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserSessions> GetByIdAsync(UserSessions entity)
        {
            var response = await _dbclient.GetByIdAsync(_mapper.Map<UserSessionsDTO>(entity));
            return _mapper.Map<UserSessions>(response);
        }

        public async Task<UserSessions> GetByTokenAsync(UserSessions session)
        {
            var response = await _dbclient.GetSessionByToken(_mapper.Map<UserSessionsDTO>(session));
            return _mapper.Map<UserSessions>(response);
        }

        public Task<bool> TerminateAsync(UserSessions Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UserSessions entity)
        {
            return await _dbclient.UpdateAsync(_mapper.Map<UserSessionsDTO>(entity));
        }
        Task<bool> IRepository<UserSessions>.DeleteAsync(UserSessions entity)
        {
            throw new NotImplementedException();
        }

    }
}
