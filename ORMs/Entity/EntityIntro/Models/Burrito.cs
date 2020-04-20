using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// for not mapping a field to the db
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityIntro.Models
{
    public class Burrito
    {
        [Key]
        public int BurritoId { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tortilla { get; set; }
        [Required]
        public string Meat { get; set; }
        [Required]
        public string Rice { get; set; }
        [Required]
        public string Beans { get; set; }
        
        // Navigation Property
        public List<VegRito> VegetablesInBurrito { get; set; }


        [Required]
        public bool Guac { get; set; }

        // Foreign Key to the RitoMaster
        [Display(Name="Master: ")]
        public int RitoMasterId { get; set; }
        // Navigation property: This is not actually translated to the database
        public RitoMaster RitoMaster { get; set; }


        // DATETIMES
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } =  DateTime.Now;

        [NotMapped]
        [Required]
        [Compare("Meat")]
        public string ConfirmMeat { get; set; }
    }
}