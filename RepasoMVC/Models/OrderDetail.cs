using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepasoMVC.Models
{
    public class OrderDetail
    {
        public int ProductID { get; set; }

        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; } 
    }
}