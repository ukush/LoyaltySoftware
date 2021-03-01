using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    public class Address
    {
        public static int addressId { get; set; }
        public static string country { get; set; }
        public static string county { get; set; }
        public static string streetName { get; set; }
        public static int streetNumber { get; set; }
        public static string postcode { get; set; }
    }
}
