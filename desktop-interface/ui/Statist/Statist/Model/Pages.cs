using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    public class Pages
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "site_id")]
        public int SiteId { get; set; }

        [JsonProperty(PropertyName = "found_date_time")]
        public DateTime FoundDateTime { get; set; }

        [JsonProperty(PropertyName = "last_scan_date")]
        public DateTime LastScanDate { get; set; }
        public ICollection<PersonPageRanks> PersonPageRanks { get; set; } = new List<PersonPageRanks>();

        public static Pages GetPageById(List<Pages> pages, int id)
        {
            return pages.Where(i => i.Id == id).FirstOrDefault();
        }
        public static List<Pages> GetPagesBySiteId(List<Pages> pages, int id)
        {
            return pages.Where(si => si.SiteId == id).ToList();
        }
    }
}
