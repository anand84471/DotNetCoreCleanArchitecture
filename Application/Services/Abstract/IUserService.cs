using Core.Entities.Concrete;
using Core.Entities.HttpResponse;
using Core.Entities.HttpResponse.UserResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IUserService
    {
        Task<UserModel> AddAsync(User user);
        Task<UserModel> ValidateUserAsync(User user);
        Task<MasterResponse<PasswordResetResponse>> SendPasswordRecoveryAsync(User user);
        Task<bool> ValidatePasswordRecoveryAsync(User user);
        Task<bool> ProcessPasswordResetAsync(User user);
        Task<UserModel> AddFbAsync(User user);
        Task<UserModel> ValidateFbAsync(User user);
        Task<UserModel> AddGoogleAsync(User user);
        Task<UserModel> ValidateGoogleAsync(User user);
    }
}
