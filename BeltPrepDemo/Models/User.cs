using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrepDemo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "You must put a First Name here.")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must put a Last Name here.")]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long.")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get 
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required(ErrorMessage = "You must put an Email here.")]
        [MinLength(2, ErrorMessage = "Email must be at least 2 characters long.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters long.")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [Compare("Password")]
        public string ConfirmPW { get; set; }

        // Navigation properties for the food trucks created and the reviews left
        public List<FoodTruck> FoodTrucks { get; set; }
        public List<Review> Reviews { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}