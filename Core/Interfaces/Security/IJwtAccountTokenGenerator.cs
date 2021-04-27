using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Security
{
    public interface IJwtAccountTokenGenerator
    {
        string GenerateJSONWebToken(User userInfo);
        long ValidateToken(string authToken);
    }
}
