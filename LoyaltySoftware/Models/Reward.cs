using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    public class Reward
    {
        public static int rewardId { get; set; }
        public static string rewardName { get; set; }
        public static int pointsToClaim { get; set; }
        public static string description { get; set; }
    }
}