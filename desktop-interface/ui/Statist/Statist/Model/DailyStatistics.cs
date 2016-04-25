using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    public class DailyStatistics
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime LastScanDate { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }
    }
}
