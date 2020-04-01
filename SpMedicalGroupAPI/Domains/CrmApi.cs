using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpMedicalGroupAPI.Domains
{
    public class CrmApi
    {
        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("status")]
        public bool status { get; set; }

        [JsonProperty("mensagem")]
        public string mensagem { get; set; }

        [JsonProperty("api_limite")]
        public int api_limite { get; set; }

        [JsonProperty("api_consultas")]
        public int api_consultas { get; set; }

        [JsonProperty("item")]
        public ICollection<CrmDomain> item { get; set; }
    }
}