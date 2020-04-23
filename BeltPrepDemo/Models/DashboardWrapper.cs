using System;
using System.Collections.Generic;

namespace BeltPrepDemo.Models
{
    public class DashboardWrapper
    {
        public User LoggedUser { get; set; }
        public List<FoodTruck> AllTrucks { get; set; }
    }
}