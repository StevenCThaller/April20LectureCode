using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNETDemo.Models
{
    public class SideKick
    {
        [Required(ErrorMessage="You gotta put something here.")]
        public string Name { get; set; }


        public SideKick()
        {}
        public SideKick(string name)
        {
            Name = name;
        }
    }
}