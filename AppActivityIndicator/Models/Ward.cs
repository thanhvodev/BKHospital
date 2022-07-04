using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class Ward
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
