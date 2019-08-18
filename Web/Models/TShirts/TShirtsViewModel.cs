using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_T.Models
{
    public class TShirtsViewModel 
    {
        public string Id { get; set; }
        public string Name { get; set; } = "GOT T";

        public string Picture { get; set; } = "Got2.jpg";

        public List<string> Sizes { get; set; } = new List<string>() { "S", "M", "L", "XL" }; //TODO:make it enum 

        public List<string> Colours { get; set; }=new List<string>() { "Red", "Black", "Blue", "White" }; //TODO: make it enum

        public List<string> Models { get; set; } = new List<string>() { "Polo", "Default" };//TODO:make it enum
   
    }
}
