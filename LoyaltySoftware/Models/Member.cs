﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    public class Member
    {
        public static int UserId { get; set; }
        public static string firstName { get; set; }
        public static string surname { get; set; }
        public static string dateOfBirth { get; set; }
        public static int telephone { get; set; }
        public static string email { get; set; }
        public static DateTime creation_timestamp { get; set; }
        public static bool inNewMember { get; set; }
        public static int points { get; set; }
    }
}
