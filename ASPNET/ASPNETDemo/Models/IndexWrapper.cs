using System;
using System.Collections.Generic;

namespace ASPNETDemo.Models
{
    public class IndexWrapper
    {
        public SuperHero Hero { get; set; }
        public List<SideKick> SideKicks { get; set; }
        public SideKick Kick { get; set; }
    }
}