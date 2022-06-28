using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Services
{
    internal class Ward
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
