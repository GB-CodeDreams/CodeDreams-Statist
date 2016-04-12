using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    public class GeneralStatistics
    {
        [JsonProperty(PropertyName = "query_word")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }
    }
}
