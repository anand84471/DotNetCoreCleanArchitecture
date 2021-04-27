using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.HttpResponse.UserResponse
{
    public class UserModel
    {
        public long UserId { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("email_id")]
        public string EmailId { get; set; }
        [JsonProperty("token")]
        public string JwtToken { get; set; }
    }
}
