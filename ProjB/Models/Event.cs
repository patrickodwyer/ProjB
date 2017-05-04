using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjB.Models
{
    public class Event
    {
       
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Event ID")]
        public int EventID { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public string Name { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Venue")]
        public String Venue { get; set; }
     
        [Display(Name = "Price (€)")]
        public double Price { get; set; }

        [Display(Name = "Start Time")]
         public string StartTime { get; set; }
       
        
        public virtual ICollection<Customer> Customers { get; set; }

        
       
        
     
    }
}