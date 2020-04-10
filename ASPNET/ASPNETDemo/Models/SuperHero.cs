using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETDemo.Models
{
    public class SuperHero
    {
        [Required(ErrorMessage="You must enter a name")]
        [MinLength(3, ErrorMessage="This name must be at least 3 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Don't worry, we won't ruin the secret. You can tell us this hero's alias")]
        [MinLength(3, ErrorMessage="This alias must be at least 3 characters long.")]
        public string Alias { get; set; }

        [Required]
        [Range(18, Double.PositiveInfinity, ErrorMessage="Superhero must be at least 18 years old.")]
        public int Age { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15, ErrorMessage="I asked for a power, not a book.")]
        public string MainPower { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(15, ErrorMessage="I asked for a weakness, not a book.")]
        public string MainWeakness { get; set; }
        [Required]
        public string SideKick { get; set; }

        public SuperHero()
        {
            Name = "Bruce Wayne";
            Alias = "Batman";
            Age = 35;
            MainPower = "Money";
            MainWeakness = "Bullets";
            SideKick = "Robin";
        }
        public SuperHero(string name, string alias, int age, string mainPower, string mainWeakness, string sideKick)
        {
            Name = name;
            Alias = alias;
            Age = age;
            MainPower = mainPower;
            MainWeakness = mainWeakness;
            SideKick = sideKick;
        }
    }
}