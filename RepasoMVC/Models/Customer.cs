using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepasoMVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public int LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}