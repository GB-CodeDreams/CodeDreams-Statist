using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    class Pages
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int SiteId { get; set; }
        public DateTime FoundDateTime { get; set; }
        public DateTime LastScanDate { get; set; }
        public ICollection<PersonPageRanks> PersonPageRanks { get; set; } = new List<PersonPageRanks>();
    }
}
