using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Proj_SuperMarket.Models;

namespace Proj_SuperMarket
{
    public class MarketContext:DbContext
    {
        public MarketContext() : base("dbconn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supply> supplies { get; set; }
        public DbSet<Sales> sales { get; set; }
    }
}