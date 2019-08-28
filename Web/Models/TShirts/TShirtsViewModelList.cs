using Shop_T.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtShop.Models.TShirts
{
    public class TShirtsViewModelList
    {
        public TShirtsViewModelList()
        {
            TShirtsList = new HashSet<TShirtsViewModel>();
        }
        public HashSet<TShirtsViewModel> TShirtsList { get; set; }
    }
}
