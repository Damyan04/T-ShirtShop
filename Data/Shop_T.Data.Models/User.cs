using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_T.Data.Models
{
    public class User : IBaseModel
    {
        //      - Id(string)
        //- Username(string)
        //- Password(string)
        //- Email(string)
        //- Full Name(string)
        //- Phone Number(string)
        //- List of Adresses(List string)
        //- TotalSpent(decimal)
        //- Discount(decimal)
        //- List of Orders(List)
        public string Id { get ; set ; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Address> Addresses { get; set; } //may need classs Addresses

        public decimal TotalSpent { get; set; }

        public decimal Discount { get; set; }

        public List<Order> Orders { get; set; }

        public string Role { get; set; } //neeed research here
    }
}
