using Core.Entities.Concrete;
using Core.Entities.Concrete.UserEntities;
using Core.Entities.HttpResponse;
using Core.Entities.HttpResponse.UserResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IAccountService
    {
        Task<ResponseBase> UpdateBaicProfileDetailsAsync(User user);
        Task<UserProfileDetails> GetBaicProfileDetailsAsync(long Id);
        Task<bool> LogoutAsync(UserSessions session);
    }
}
