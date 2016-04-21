using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    public class Keywords
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "name_2")]
        public string Name2 { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public int Distance { get; set; }
    }
}
