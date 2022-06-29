using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Services
{
    internal class District
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
