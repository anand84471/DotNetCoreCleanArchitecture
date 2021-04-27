using Core.Entities.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    [Serializable]
    public class Country:CountryBase
    {
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public char[] Iso { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NiceName { get; set; }
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public char[] Iso3 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int NumCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int PhoneCode { get; set; }

    }
}
