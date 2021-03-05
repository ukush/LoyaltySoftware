﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    public class Reward
    {
        public int rewardId { get; set; }
        public string rewardName { get; set; }
        public int pointsToClaim { get; set; }
        public string description { get; set; }
    }
}