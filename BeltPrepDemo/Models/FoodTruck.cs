using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrepDemo.Models
{
    public class FoodTruck
    {
        [Key]
        public int FoodTruckId { get; set; }

        [Required(ErrorMessage = "You must input a name for this truck.")]
        [MinLength(5, ErrorMessage = "Truck name not long enough, minimum 5 characters.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "You must enter a description for this food truck.")]
        [MinLength(10, ErrorMessage = "You must write at least 10 characters for your description.")]
        public string Description { get; set; }

        // Foreign Key for the creator
        [Required]
        public int UserId { get; set; }

        // Navigation property for the truck's creator.
        public User User { get; set; }

        // Navigation property for the M2M with Style
        public List<TruckStyle> TruckStyles { get; set; }

        // Navigation property for O2M with the Reviews left for this truck
        public List<Review> Reviews { get; set; } = new List<Review>();

        [NotMapped]
        public double AvgRating
        {
            get
            {
                double avg = 0;
                foreach(Review review in Reviews)
                {
                    avg += review.Rating;
                }
                avg /= Reviews.Count;
                if(Reviews.Count == 0) return 0;
                return avg;
            }
        }


        // JUST FOR FORMS DON'T MIND ME
        [NotMapped]
        public List<SelectListItem> Styles { get; set; } = new List<SelectListItem>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
