using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_T.Models.TShirtsViewModel
{
    public class TShirtsViewModel 
    {
        public string Name { get; set; } = "GOT T";

        public string Picture { get; set; } = "~/img/tshirts/Got2.jpeg";

        public List<string> Sizes { get; set; } = new List<string>() { "S", "M", "L", "XL" }; //TODO:make it enum 

        public List<string> Colours { get; set; }=new List<string>() { "Red", "Black", "Blue", "White" }; //TODO: make it enum

        public List<string> Models { get; set; } = new List<string>() { "Polo", "Default" };//TODO:make it enum
   
    }
}
