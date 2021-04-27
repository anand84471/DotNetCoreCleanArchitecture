using DAL.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PostgresqlRepo.Abstract
{
    public interface ISessionDbClient<T>:IDbClient<T>
    {
        Task<UserSessionsDTO> GetSessionByToken(UserSessionsDTO user);
    }
}
