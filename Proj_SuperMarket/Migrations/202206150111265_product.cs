namespace Proj_SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductId = c.Int(nullable: false),
                        ProductPrice = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.Dataproperties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Dataproperties",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        BillingAddress = c.String(),
                        city = c.String(),
                        Pincode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            DropTable("dbo.Products");
        }
    }
}
