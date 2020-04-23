using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrepDemo.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        // Foreign Key and navigation property for the user who left this review
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }

        [Required(ErrorMessage = "You must leave a rating")]
        [Range(1,5, ErrorMessage="Rating must be between 1 and 5 stars.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "You must leave an actual review.")]
        [MinLength(10, ErrorMessage = "You must write at least 10 characters for your review.")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
