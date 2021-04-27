using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.UserEntities
{
    public class UserSessions:Timeline
    {
        public long SessionId { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        public bool IsSessionLogout { get; set; }
        public DateTime? SessionLogoutTime { get; set; }
    }
}
