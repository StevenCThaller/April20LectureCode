using System;
using System.Collections.Generic;

namespace BeltPrepDemo.Models
{
    public class NewTruckWrapper
    {
        public FoodTruck TruckForm { get; set; }
        public List<SelectListItem> StyleList { get; set; }
        
    }
}