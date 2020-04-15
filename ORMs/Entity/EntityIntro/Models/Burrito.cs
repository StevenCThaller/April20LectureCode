using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Vegetable { get; set; }
        [Required]
        public bool Guac { get; set; }

        // DATETIMES
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } =  DateTime.Now;
    }
}