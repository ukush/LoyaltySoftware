using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltySoftware.Models
{
    public class Address
    {
        public int addressId { get; set; }
        
        [Display(Name = "Country")]
        [Required]
        public string country { get; set; }
       
        [Display(Name = "County")]
        public string county { get; set; }

        [Display(Name = "Street Name")]
        [Required]
        public string street_name{ get; set; }
        
        [Display(Name = "Street Number")]
        [Required]
        public int street_number { get; set; }

        [Display(Name = "Street Number")]
        [Required]
        public string postcode { get; set; }
    }
}
