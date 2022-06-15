using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proj_SuperMarket.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}