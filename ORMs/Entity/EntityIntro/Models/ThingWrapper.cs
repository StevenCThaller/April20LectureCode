using System;
using System.Collections.Generic;

namespace EntityIntro.Models
{
    public class ThingWrapper
    {
        // This is the burrito for the form
        public Burrito FormModel { get; set; }

        // This list of masters will be used in a dropdown on the form
        public List<RitoMaster> AllMasters { get; set; }

        // This list of veggies will be displayed I guess idk
        public List<Vegetable> AllVeggies { get; set; }
    }
}
