using System;
using System.Collections.Generic;

namespace W1D2Breakout
{
    class IceCream
    {
        public string Flavor;
        public string Color;
        private List<string> Ingredients;

        public bool IsDelicious
        {
            get
            {
                if(Flavor == "Rocky Road")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IceCream()
        {
            Flavor = "Garbage";
            Color = "Brown";
            Ingredients = new List<string>{"Garbage", "Juice", "Sauce", "Poop"};
        }

        public bool IsItDelicious()
        {
            if(Flavor == "Rocky Road")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}