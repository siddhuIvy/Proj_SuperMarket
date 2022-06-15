using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proj_SuperMarket.Models
{
    public class Sales
    {
        [Key]
        public int ProductID { get;set;}
        
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public int price { get; set; }
    }
    
}