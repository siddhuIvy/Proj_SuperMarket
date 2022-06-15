namespace Proj_SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Supplies");
        }
    }
}
