using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    internal class Ward
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
