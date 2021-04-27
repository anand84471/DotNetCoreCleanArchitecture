using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO.User
{
    public class UserSessionsDTO: TimelineDTO
    {
        public long SessionId { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        public bool IsSessionLogout { get; set; }
        public DateTime? SessionLogoutTime { get; set; }
    }
}
