using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjB.Models
{
    public class Customer
    {

      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerID { get; set; }
    

        // Having a property called <entity>Id defines a relationship
        public int EventID { get; set; }

        public virtual Event Event { get; set; }
    }
}