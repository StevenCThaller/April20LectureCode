using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityIntro.Models
{
    public class VegRito
    {
        [Key]
        public int VegRitoId { get; set; }

        public int BurritoId { get; set; }
        public int VegetableId { get; set; }

        // Navigation properties
        public Burrito Burrito { get; set; }
        public Vegetable Vegetable { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}