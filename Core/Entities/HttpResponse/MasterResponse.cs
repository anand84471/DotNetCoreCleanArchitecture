using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.HttpResponse
{
    public class MasterResponse<T>:ResponseBase
    {
        [JsonProperty("data")]
        public T data { get; set; }
    }
}
