using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Models
{
    public class RitoMaster
    {
        [Key]
        public int RitoMasterId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        // Navigation property for the List of Burrito objects created
        // by any given RitoMaster
        public List<Burrito> Burritos { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}