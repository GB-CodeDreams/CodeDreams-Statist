using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonPageRanks> PersonPageRanks { get; set; } = new List<PersonPageRanks>();
    }
}
