using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrepDemo.Models
{
    public class Style
    {
        [Key]
        public int StyleId { get; set; }

        [Required(ErrorMessage="You must input a style type for this truck.")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters for the style of the truck food.")]
        [MaxLength(15, ErrorMessage = "Ok, I asked for cuisine style, not your life story.")]
        public string Name { get; set; }

        // Navigation Property for the M2M with Food Trucks
        public List<TruckStyle> TruckStyles { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}