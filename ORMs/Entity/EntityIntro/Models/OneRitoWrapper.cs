using System;
using System.Collections.Generic;

namespace EntityIntro.Models
{
    public class OneRitoWrapper
    {
        public Burrito ThisRito { get; set; }
        public List<Vegetable> Veggies { get; set; }
        public VegRito VegRito { get; set; }
    }
}
