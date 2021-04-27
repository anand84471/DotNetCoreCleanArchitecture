using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.HttpResponse
{
    public class ListResponse<T>:ResponseBase
    {
        [JsonProperty("data")]
        public IEnumerable<T> Records { get; set; }
    }
}
