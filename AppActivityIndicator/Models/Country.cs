using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    internal class Country
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
