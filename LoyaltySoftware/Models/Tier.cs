using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    public class Tier
    {
        public string tierName { get; set; }
        public string description { get; set; }
        public int pointsNeeded { get; set; }
    }
}
