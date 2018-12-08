using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
        public string Mobile { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public RelationType RelationType { get; set; }

        public int RelationTypeId { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string Country { get; set; }


    }
}