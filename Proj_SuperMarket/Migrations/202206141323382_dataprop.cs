namespace Proj_SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataprop : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dataproperties");
        }
    }
}
