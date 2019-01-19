using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepasoMVC.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}