using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
