using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrepDemo.Models
{
    public class TruckStyle
    {
        [Key]
        public int TruckStyleId { get; set; }

        public int StyleId { get; set; }
        public int FoodTruckId { get; set; }

        // Navigation Properties
        public Style Style { get; set; }
        public FoodTruck FoodTruck { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}