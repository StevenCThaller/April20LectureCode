using System;

namespace BeltPrepDemo.Models
{
    public class SelectListItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public bool Selected { get; set; }

        public SelectListItem() {}
        public SelectListItem(int id, string name) 
        {
            ItemId = id;
            ItemName = name;
            Selected = false;
        }
    }
}