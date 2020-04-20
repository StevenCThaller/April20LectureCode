using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EntityIntro.Models
{
    public class Vegetable
    {
        [Key]
        public int VegetableId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property
        public List<VegRito> BurritosWithVegetable { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}